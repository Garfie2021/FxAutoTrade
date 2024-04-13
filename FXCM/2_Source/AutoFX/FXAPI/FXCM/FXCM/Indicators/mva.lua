-- The indicator corresponds to the Moving Average indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 4 "Trend Calculations" (page 67-70)

-- initializes the indicator
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Moving Averages");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 7, 1, 10000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrDIP", resources:get("param_clrDIP_name"), resources:get("param_clrDIP_description"), core.rgb(255, 255, 0));
    indicator.parameters:addInteger("widthDIP", resources:get("param_widthDIP_name"), resources:get("param_widthDIP_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleDIP", resources:get("param_styleDIP_name"), resources:get("param_styleDIP_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleDIP", core.FLAG_LEVEL_STYLE);
end

local first = 0;
local n = 0;
local source = nil;
local out = nil;

-- initializes the instance of the indicator
function Prepare()
    source = instance.source;
    n = instance.parameters.N;
    first = n + source:first() - 1;
    local name = profile:id() .. "(" .. source:name() .. "," .. n .. ")";
    instance:name(name);
    out = instance:addStream("MVA", core.Line, name, "MVA", instance.parameters.clrDIP, first)
    out:setWidth(instance.parameters.widthDIP);
    out:setStyle(instance.parameters.styleDIP);
end

-- calculate the value
function Update(period)
    if (period >= first) then
        out[period] = mathex.avg(source, period - n + 1, period);
    end
end
