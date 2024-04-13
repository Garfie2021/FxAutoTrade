-- AROON Indicator
-- Developed by Tushar Chande in 1995, Aroon is an indicator system
-- that can be used to determine whether a stock is trending or not and
-- how strong the trend is. "Aroon" means "Dawn's Early Light" in
-- Sanskrit and Chande choose that name for this indicator since it is
-- designed to reveal the beginning of a new trend.
-- The Aroon indicator system consists of two lines, 'Aroon(up)' and
-- 'Aroon(down)'. It takes a single parameter which is the number of time
-- periods to use in the calculation. Aroon(up) is the amount of time (on
-- a percentage basis) that has elapsed between the start of the time
-- period and the point at which the highest price during that time
-- period occurred. If the stock closes at a new high for the given
-- period, Aroon(up) will be +100. For each subsequent period that passes
-- without another new high, Aroon(up) moves down by an amount equal to
-- (1 / # of periods) x 100.
-- Technically, the formula for Aroon(up) is:
-- [[ (# of periods) - (# of periods since highest high during that time) ] / (# of periods) ] x 100--
-- The formula for Aroon(down) is :
-- [[ (# of periods) - (# of periods since lowest low during that time) ] / (# of periods) ] x 100

-- Indicator profile initialization routine
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Trend");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 25, 3, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrUp", resources:get("param_clrUp_name"), resources:get("param_clrUp_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthUP", resources:get("param_widthUP_name"), resources:get("param_widthUP_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleUP", resources:get("param_styleUP_name"), resources:get("param_styleUP_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleUP", core.FLAG_LEVEL_STYLE);

    indicator.parameters:addColor("clrDown", resources:get("param_clrDown_name"), resources:get("param_clrDown_description"), core.rgb(0, 255, 0));
    indicator.parameters:addInteger("widthDOWN", resources:get("param_widthDOWN_name"), resources:get("param_widthDOWN_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleDOWN", resources:get("param_styleDOWN_name"), resources:get("param_styleDOWN_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleDOWN", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local N;

local firstPeriod;
local source = nil;

-- Streams block
local UP = nil;
local DOWN = nil;

-- Routine
function Prepare()
    N = instance.parameters.N;
    source = instance.source;
    firstPeriod = source:first() + N - 1;

    local name = profile:id() .. "(" .. source:name() .. ", " .. N .. ")";
    instance:name(name);
    UP = instance:addStream("UP", core.Line, name .. ".UP", "UP", instance.parameters.clrUp, firstPeriod)
    UP:setWidth(instance.parameters.widthUP);
    UP:setStyle(instance.parameters.styleUP);
    UP:setPrecision(2);
    DOWN = instance:addStream("DOWN", core.Line, name .. ".DOWN", "DOWN", instance.parameters.clrDown, firstPeriod)
    DOWN:setWidth(instance.parameters.widthDOWN);
    DOWN:setStyle(instance.parameters.styleDOWN);
    DOWN:setPrecision(2);
end

-- Indicator calculation routine
function Update(period)
    local vmin, pmin;
    local vmax, pmax;
    if period >= firstPeriod then
        vmin, vmax, pmin, pmax = mathex.minmax(source, period - N + 1, period);
        UP[period] = (N - (period - pmax)) / N * 100;
        DOWN[period] = (N - (period - pmin)) / N * 100;
    end
end
