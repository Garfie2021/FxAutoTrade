-- initializes the indicator
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Moving Averages");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 7, 2, 10000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clr", resources:get("param_clr_name"), resources:get("param_clr_description"), core.rgb(192, 192, 131));
    indicator.parameters:addInteger("width", resources:get("param_width_name"), resources:get("param_width_description"), 1, 1, 5);
    indicator.parameters:addInteger("style", resources:get("param_style_name"), resources:get("param_style_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("style", core.FLAG_LEVEL_STYLE);
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
    out = instance:addStream("SMMA", core.Line, name, "SMMA", instance.parameters.clr,  first)
    out:setWidth(instance.parameters.width);
    out:setStyle(instance.parameters.style);
end

-- calculate the value
function Update(period)
    if (period == first) then
        out[period] = mathex.avg(source, period - n + 1, period);
    elseif (period > first) then
        local sum;
        sum  = mathex.sum(source, period - n, period - 1);
        out[period] = (out[period - 1] * n - out[period - 1] + source[period]) / n;
    end
end

