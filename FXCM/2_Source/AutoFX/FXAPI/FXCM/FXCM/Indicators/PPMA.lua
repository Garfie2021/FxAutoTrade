-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 4 "Trend Calculations" (page 73)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Moving Averages");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrPPMA", resources:get("param_clrPPMA_name"), resources:get("param_clrPPMA_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthPPMA", resources:get("param_widthPPMA_name"), resources:get("param_widthPPMA_description"), 1, 1, 5);
    indicator.parameters:addInteger("stylePPMA", resources:get("param_stylePPMA_name"), resources:get("param_stylePPMA_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("stylePPMA", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;
local typicalPrice = nil;
local typicalPriceMA = nil;
local ppmaFirst = nil;

-- Streams block
local PPMA = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    source = instance.source;
    first = n + source:first() - 1;
    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    PPMA = instance:addStream("PPMA", core.Line, name, "PPMA", instance.parameters.clrPPMA, first)
    PPMA:setWidth(instance.parameters.widthPPMA);
    PPMA:setStyle(instance.parameters.stylePPMA);
    ppmaFirst = PPMA:first();
end

-- Indicator calculation routine
function Update(period, mode)
    if period >= ppmaFirst then
        PPMA[period] = mathex.avg(source.typical, period - n + 1, period);
    end
end



