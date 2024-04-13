-- The indicator corresponds to the ADX indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 23 "Risk Control" (page 609-611)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Trend Strength");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 1, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrDIP", resources:get("param_clrDIP_name"), resources:get("param_clrDIP_description"), core.rgb(0, 255, 0));
    indicator.parameters:addInteger("widthDIP", resources:get("param_widthDIP_name"), resources:get("param_widthDIP_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleDIP", resources:get("param_styleDIP_name"), resources:get("param_styleDIP_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleDIP", core.FLAG_LEVEL_STYLE);
    
    indicator.parameters:addColor("clrDIM", resources:get("param_clrDIM_name"), resources:get("param_clrDIM_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthDIM", resources:get("param_widthDIM_name"), resources:get("param_widthDIM_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleDIM", resources:get("param_styleDIM_name"), resources:get("param_styleDIM_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleDIM", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;
local avgPlusDM = nil;
local avgMinusDM = nil;
local tAbs = math.abs;

-- Streams block
local DIP = nil;
local DIM = nil;
local emaDIP = nil;
local emaDIM = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    source = instance.source;
    first = source:first() + 1;

    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    avgPlusDM = instance:addInternalStream(0, 0);
    avgMinusDM = instance:addInternalStream(0, 0);

    DIP = instance:addStream("DIP", core.Line, name .. ".DIP", "DI+", instance.parameters.clrDIP, first)
    DIP:setWidth(instance.parameters.widthDIP);
    DIP:setStyle(instance.parameters.styleDIP);
    DIP:setPrecision(4);
    DIM = instance:addStream("DIM", core.Line, name .. ".DIM", "DI-", instance.parameters.clrDIM, first)
    DIM:setWidth(instance.parameters.widthDIM);
    DIM:setStyle(instance.parameters.styleDIM);
    DIM:setPrecision(4);
    emaDIP = core.indicators:create("EMA", avgPlusDM, n);
    emaDIM = core.indicators:create("EMA", avgMinusDM, n);
end

function TrueRangeCustom(period)
    local num1 = tAbs(source.high[period] - source.low[period]);
    local num2 = tAbs(source.high[period] - source.close[period - 1]);
    local num3 = tAbs(source.close[period - 1] - source.low[period]);
    return math.max(num1, num2, num3);
end

-- Indicator calculation routine
function Update(period, mode)
    avgPlusDM[period] = 0;
    avgMinusDM[period] = 0;

    if period >= first then
        local upperMove = 0;
        local lowerMove = 0;
        local TR = 0;

        upperMove = source.high[period] - source.high[period - 1];
        lowerMove = source.low[period - 1] - source.low[period];
        if (upperMove < 0) then upperMove = 0 end
        if (lowerMove < 0) then lowerMove = 0 end
        if (upperMove == lowerMove) then
            upperMove = 0;
            lowerMove = 0;
        elseif (upperMove < lowerMove) then
            upperMove = 0;
        elseif (lowerMove < upperMove) then
            lowerMove = 0;
        end

        TR = TrueRangeCustom(period);
        if (TR == 0) then
            avgPlusDM[period] = 0;
            avgMinusDM[period] = 0;
        else
            avgPlusDM[period] = 100 * upperMove / TR;
            avgMinusDM[period] = 100 * lowerMove / TR;
        end
        
        emaDIP:update(mode);
        emaDIM:update(mode);

        DIP[period] = emaDIP.DATA[period];
        DIM[period] = emaDIM.DATA[period];
    --else
    --    emaDIP:update(mode);
    --    emaDIM:update(mode);
    end
end








