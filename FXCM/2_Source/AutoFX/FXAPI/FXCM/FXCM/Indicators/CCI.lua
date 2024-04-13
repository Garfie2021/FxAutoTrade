-- The indicator corresponds to the Commodity Channel Index indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 8 "Sycle Analisis" (page 209-210)

-- Indicator profile initialization routine
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Classic Oscillators");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrCCI", resources:get("param_clrCCI_name"), resources:get("param_clrCCI_description"), core.rgb(0, 255, 255));
    indicator.parameters:addInteger("widthCCI", resources:get("param_widthCCI_name"), resources:get("param_widthCCI_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleCCI", resources:get("param_styleCCI_name"), resources:get("param_styleCCI_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleCCI", core.FLAG_LEVEL_STYLE);

    indicator.parameters:addGroup("Levels");
    -- Overbought/oversold level
    indicator.parameters:addInteger("overbought", resources:get("param_level_overbought_name"), resources:get("param_level_overbought_description"), 100, -1000, 1000);
    indicator.parameters:addInteger("oversold", resources:get("param_level_oversold_name"), resources:get("param_level_oversold_description"), -100, -1000, 1000);
    indicator.parameters:addInteger("level_overboughtsold_width", resources:get("param_level_overboughtsold_width_name"), resources:get("param_level_overboughtsold_width_description"), 1, 1, 5);
    indicator.parameters:addInteger("level_overboughtsold_style", resources:get("param_level_overboughtsold_style_name"), resources:get("param_level_overboughtsold_style_description"), core.LINE_SOLID);
    indicator.parameters:addColor("level_overboughtsold_color", resources:get("param_level_overboughtsold_color_name"), resources:get("param_level_overboughtsold_color_description"), core.rgb(255, 255, 0));
    indicator.parameters:setFlag("level_overboughtsold_style", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;
local tp = nil;

-- Streams block
local CCI = nil;

-- Routine
function Prepare()
    assert(instance.parameters.oversold < instance.parameters.overbought, resources:get("error_bought_bigger_sold"));

    n = instance.parameters.N;
    source = instance.source.typical;
    first = source:first();

    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    first = source:first() + n - 1;
    CCI = instance:addStream("CCI", core.Line, name, "CCI", instance.parameters.clrCCI, first);
    CCI:setWidth(instance.parameters.widthCCI);
    CCI:setStyle(instance.parameters.styleCCI);
    CCI:setPrecision(2);

    CCI:addLevel(instance.parameters.oversold, instance.parameters.level_overboughtsold_style, instance.parameters.level_overboughtsold_width, instance.parameters.level_overboughtsold_color);
    CCI:addLevel(0);
    CCI:addLevel(instance.parameters.overbought, instance.parameters.level_overboughtsold_style, instance.parameters.level_overboughtsold_width, instance.parameters.level_overboughtsold_color);
end

-- Indicator calculation routine
function Update(period)
    if period >= first then
        local from = period - n + 1;
        local to = period;

        local mean = mathex.avg(source, from, to);
        local meandev = mathex.meandev(source, from, to);

        if (meandev == 0) then
            CCI[period] = 0;
        else
            CCI[period] = (source[period] - mean) / (meandev * 0.015);
        end
    end
end







