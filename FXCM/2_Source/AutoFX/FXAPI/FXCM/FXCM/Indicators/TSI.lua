-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 6 "Momentum and Oscillators" (page 145)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Oscillators");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 7, 2, 1000);
    indicator.parameters:addInteger("M", resources:get("param_M_name"), resources:get("param_M_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrTSI", resources:get("param_clrTSI_name"), resources:get("param_clrTSI_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthTSI", resources:get("param_widthTSI_name"), resources:get("param_widthTSI_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleTSI", resources:get("param_styleTSI_name"), resources:get("param_styleTSI_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleTSI", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;
local m;

local first;
local source = nil;
local delta = nil;
local absDelta = nil;
local ema_r1 = nil;
local ema_r2 = nil;
local ema_s1 = nil;
local ema_s2 = nil;
local deltaFirst = nil;

-- Streams block
local TSI = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    m = instance.parameters.M;
    source = instance.source;

    delta = instance:addInternalStream(source:first() + 1, 0);
    absDelta = instance:addInternalStream(source:first() + 1, 0);
    deltaFirst = delta:first();
    
    ema_r1 = core.indicators:create("EMA", delta, n);
    ema_r2 = core.indicators:create("EMA", absDelta, n);
    ema_s1 = core.indicators:create("EMA", ema_r1.DATA, m);
    ema_s2 = core.indicators:create("EMA", ema_r2.DATA, m);
    
    first = ema_s1.DATA:first();
    
    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ", " .. m .. ")";
    instance:name(name);
    TSI = instance:addStream("TSI", core.Line, name, "TSI", instance.parameters.clrTSI, first)
    TSI:setWidth(instance.parameters.widthTSI);
    TSI:setStyle(instance.parameters.styleTSI);
    TSI:setPrecision(2);
end

-- Indicator calculation routine
function Update(period, mode)
    if period >= deltaFirst then
        delta[period] = source[period] - source[period - 1];
        absDelta[period] = math.abs(delta[period]);
    end
    
    ema_r1:update(mode);
    ema_r2:update(mode);
    ema_s1:update(mode);
    ema_s2:update(mode);
    
    if period >= first then
        if ema_s2.DATA[period] == 0 then
            TSI[period] = 0;
        else
            TSI[period] = 100 * ema_s1.DATA[period] / ema_s2.DATA[period];
        end
    end
end

