-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 17 "Adaptive Techniques" (page 441)

-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Trend");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 14, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrMD", resources:get("param_clrMD_name"), resources:get("param_clrMD_description"), core.rgb(0, 255, 255));
    indicator.parameters:addInteger("widthMD", resources:get("param_widthMD_name"), resources:get("param_widthMD_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleMD", resources:get("param_styleMD_name"), resources:get("param_styleMD_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleMD", core.FLAG_LEVEL_STYLE);
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local n;

local first;
local source = nil;

-- Streams block
local MD = nil;

-- Routine
function Prepare()
    n = instance.parameters.N;
    source = instance.source;
    first = source:first() + 1;

    local name = profile:id() .. "(" .. source:name() .. ", " .. n .. ")";
    instance:name(name);
    MD = instance:addStream("MD", core.Line, name, "MD", instance.parameters.clrMD, first)
    MD:setWidth(instance.parameters.widthMD);
    MD:setStyle(instance.parameters.styleMD);
end

-- Indicator calculation routine
function Update(period)
    if period >= first then
	        local value = 0;
        local closePeriod = source.close[period];
        if (period == first) then
            value = closePeriod;
        else
            value = MD[period - 1];
        end
        --MD[period] = value + (closePeriod - value) / (0.6 * n * math.pow((closePeriod / value), 4));
        MD[period] = value + (closePeriod - value) / (0.6 * n * ((closePeriod / value)^4));
    end
end





