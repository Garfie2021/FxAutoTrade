-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 3 "Regression Analysis" (page 37-40)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Trend");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrLinReg", resources:get("param_clrLinReg_name"), resources:get("param_clrLinReg_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthLinReg", resources:get("param_widthLinReg_name"), resources:get("param_widthLinReg_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleLinReg", resources:get("param_styleLinReg_name"), resources:get("param_styleLinReg_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleLinReg", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;

-- Streams block
local Regression = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    source = instance.source;
    first = source:first() + n;

    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    Regression = instance:addStream("Regression", core.Line, name, "Regression", instance.parameters.clrLinReg, first)
    Regression:setWidth(instance.parameters.widthLinReg);
    Regression:setStyle(instance.parameters.styleLinReg);
end

-- Indicator calculation routine
function Update(period)
    if period >= first then
        Regression[period] = mathex.lreg(source, core.rangeTo(period, n));
    end
end

