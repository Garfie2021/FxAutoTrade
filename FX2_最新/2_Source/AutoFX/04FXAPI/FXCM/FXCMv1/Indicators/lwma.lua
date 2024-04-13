-- The indicator corresponds to the Moving Average indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 4 "Trend Calculations" (page 68-70)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Moving Averages");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrLWMA", resources:get("param_clrLWMA_name"), resources:get("param_clrLWMA_description"), core.rgb(0, 255, 0));
    indicator.parameters:addInteger("widthLWMA", resources:get("param_widthLWMA_name"), resources:get("param_widthLWMA_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleLWMA", resources:get("param_styleLWMA_name"), resources:get("param_styleLWMA_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleLWMA", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local N;

local firstPeriod;
local source = nil;

-- Streams block
local LWMA = nil;

-- Routine
function Prepare()
    N = instance.parameters.N;
    source = instance.source;
    firstPeriod = source:first() + N - 1;
    local name = profile:id() .. "(" .. source:name() .. ", " .. N .. ")";
    instance:name(name);
    LWMA = instance:addStream("LWMA", core.Line, name, "LWMA", instance.parameters.clrLWMA, firstPeriod)
    LWMA:setWidth(instance.parameters.widthLWMA);
    LWMA:setStyle(instance.parameters.styleLWMA);
end

-- Indicator calculation routine
function Update(period)
    if period >= firstPeriod then
        LWMA[period] = mathex.lwma(source, period - N + 1, period);
    end
end




