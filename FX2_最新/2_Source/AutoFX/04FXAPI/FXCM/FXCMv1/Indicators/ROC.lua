-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 10 "Volume, Open Interest, and Breadth" (page 240-241)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Classic Oscillators");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrROC", resources:get("param_clrROC_name"), resources:get("param_clrROC_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthROC", resources:get("param_widthROC_name"), resources:get("param_widthROC_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleROC", resources:get("param_styleROC_name"), resources:get("param_styleROC_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleROC", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;

-- Streams block
local ROC = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    source = instance.source;
    first = source:first() + n + 1;

    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    ROC = instance:addStream("ROC", core.Line, name, "ROC", instance.parameters.clrROC, first)
    ROC:setWidth(instance.parameters.widthROC);
    ROC:setStyle(instance.parameters.styleROC);
    local precision = math.max(2, source:getPrecision());
    ROC:setPrecision(precision);
end

-- Indicator calculation routine
function Update(period)
    if period >= first then
        ROC[period] = (source[period] / source[period - n] - 1) * 100;
    end
end

