-- EMA's reduce the lag by applying more weight to recent prices relative to older prices.
-- The formula for an exponential moving average is:
-- EMA(current) = ( (Price(current) - EMA(prev) ) x Multiplier) + EMA(prev)
-- For a period-based EMA, "Multiplier" is equal to 2 / (1 + N)
-- The indicator corresponds to the Moving Average indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 4 "Trend Calculations" (page 68-70)

-- initializes the indicator
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Moving Averages");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("N", resources:get("param_N_name"), resources:get("param_N_description"), 10, 2, 10000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("clrEMA", resources:get("param_clrEMA_name"), resources:get("param_clrEMA_description"), core.rgb(0, 255, 0));
    indicator.parameters:addInteger("widthEMA", resources:get("param_widthEMA_name"), resources:get("param_widthEMA_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleEMA", resources:get("param_styleEMA_name"), resources:get("param_styleEMA_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleEMA", core.FLAG_LEVEL_STYLE);
end

local first = 0;
local n = 0;
local k = 0;
local source = nil;
local out = nil;

-- initializes the instance of the indicator
function Prepare()
    source = instance.source;
    n = instance.parameters.N;
    k = 2.0 / (n + 1.0);
    first = source:first();
    local name = profile:id() .. "(" .. source:name() .. "," .. n .. ")";

    out = instance:addStream("EMA", core.Line, name, "EMA", instance.parameters.clrEMA,  first)
    out:setWidth(instance.parameters.widthEMA);
    out:setStyle(instance.parameters.styleEMA);
    instance:name(name);
end

-- calculate the value
function Update(period)
    if (period >= first) then
        local value = 0;
        local sourcePeriod = source[period];
        if (period == first) then
            value = sourcePeriod;
        else
            value = out[period - 1];
        end
        out[period] = (1 - k) * value + k * sourcePeriod;
    end
end

