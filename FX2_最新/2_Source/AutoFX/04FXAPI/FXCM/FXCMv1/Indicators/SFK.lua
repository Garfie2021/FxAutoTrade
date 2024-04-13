-- The indicator corresponds to the Stochastic indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 6 "Momentum and Oscillators" (page 135-137)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Classic Oscillators");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("K", resources:get("param_K_name"), resources:get("param_K_description"), 5, 2, 1000);
    indicator.parameters:addInteger("D", resources:get("param_D_name"), resources:get("param_D_description"), 5, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrFirst", resources:get("param_clrFirst_name"), resources:get("param_clrFirst_description"), core.rgb(0, 255, 0));
    indicator.parameters:addInteger("widthFirst", resources:get("param_widthFirst_name"), resources:get("param_widthFirst_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleFirst", resources:get("param_styleFirst_name"), resources:get("param_styleFirst_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleFirst", core.FLAG_LEVEL_STYLE);

    indicator.parameters:addColor("clrSecond", resources:get("param_clrSecond_name"), resources:get("param_clrSecond_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthSecond", resources:get("param_widthSecond_name"), resources:get("param_widthSecond_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleSecond", resources:get("param_styleSecond_name"), resources:get("param_styleSecond_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleSecond", core.FLAG_LEVEL_STYLE);

    indicator.parameters:addGroup("Levels");
    -- Overbought/oversold level
    indicator.parameters:addInteger("overbought", resources:get("param_level_overbought_name"), resources:get("param_level_overbought_description"), 80, 0, 100);
    indicator.parameters:addInteger("oversold", resources:get("param_level_oversold_name"), resources:get("param_level_oversold_description"), 20, 0, 100);
    indicator.parameters:addInteger("level_overboughtsold_width", resources:get("param_level_overboughtsold_width_name"), resources:get("param_level_overboughtsold_width_description"), 1, 1, 5);
    indicator.parameters:addInteger("level_overboughtsold_style", resources:get("param_level_overboughtsold_style_name"), resources:get("param_level_overboughtsold_style_description"), core.LINE_SOLID);
    indicator.parameters:addColor("level_overboughtsold_color", resources:get("param_level_overboughtsold_color_name"), resources:get("param_level_overboughtsold_color_description"), core.rgb(255, 255, 0));
    indicator.parameters:setFlag("level_overboughtsold_style", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local k;
local d;

local source = nil;
local mins = nil;
local maxes = nil;
local mva = nil;
local kFirst = nil;
local dFirst = nil;

-- Streams block
local K = nil;
local D = nil;

-- Routine
function Prepare()
    assert(instance.parameters.oversold < instance.parameters.overbought, resources:get("error_bought_bigger_sold"));

    k = instance.parameters.K;
    d = instance.parameters.D;
    source = instance.source;

    mins = instance:addInternalStream(source:first() + k, 0);
    maxes = instance:addInternalStream(source:first() + k, 0);

    local name = profile:id() .. "(" .. source:name() .. ", " .. k .. ", " .. d .. ")";
    instance:name(name);
    K = instance:addStream("K", core.Line, name .. ".K", "K", instance.parameters.clrFirst, mins:first());
    K:setWidth(instance.parameters.widthFirst);
    K:setStyle(instance.parameters.styleFirst);
    K:setPrecision(2);

    D = instance:addStream("D", core.Line, name .. ".D", "D", instance.parameters.clrSecond, K:first() + d - 1);
    D:setWidth(instance.parameters.widthSecond);
    D:setStyle(instance.parameters.styleSecond);
    D:setPrecision(2);
    kFirst = K:first();
    dFirst = D:first();

    D:addLevel(0);
    D:addLevel(instance.parameters.oversold, instance.parameters.level_overboughtsold_style, instance.parameters.level_overboughtsold_width, instance.parameters.level_overboughtsold_color);
    D:addLevel(instance.parameters.overbought, instance.parameters.level_overboughtsold_style, instance.parameters.level_overboughtsold_width, instance.parameters.level_overboughtsold_color);
    D:addLevel(100);
end

-- Indicator calculation routine
function Update(period, mode)
    if period >= kFirst then
        local minLow, minHigh;
        minLow, maxHigh = mathex.minmax(source, period - k + 1, period);
        mins[period] = source.close[period] - minLow;
        maxes[period] = maxHigh - minLow;
        if maxes[period] > 0 then
            K[period] = mins[period] / maxes[period] * 100;
        else
            K[period] = 50;
        end
    end
    if period >= dFirst then
        D[period] = mathex.avg(K, period - d + 1, period);
    end
end
