-- MACD
-- Moving Average Convergence/Divergence
-- MACD uses moving averages, which are lagging indicators, to include
-- some trend-following characteristics. These lagging indicators are
-- turned into a momentum oscillator by subtracting the longer moving
-- average from the shorter moving average. The resulting plot forms a
-- line that oscillates above and below zero, without any upper or lower
-- limits.
-- The MACD produces three lines: MACD, SIGNAL and HISTOGRAM.
-- The classic formulae is:
-- MACD = EMA(price; 12) - EMA(price; 26)
-- SIGNAL = EMA(MACD; 9)
-- HISTOGRAM = MACD - SIGNAL

-- The indicator corresponds to the MACD indicator in MetaTrader.
-- The formula is described in the Kaufman "Trading Systems and Methods" chapter 6 "Momentum and Oscillators" (page 128-130)


-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Tick);
    indicator:type(core.Oscillator);
    indicator:setTag("group", "Classic Oscillators");

    indicator.parameters:addGroup("Calculation");
    indicator.parameters:addInteger("SN", resources:get("param_SN_name"), resources:get("param_SN_description"), 12, 2, 1000);
    indicator.parameters:addInteger("LN", resources:get("param_LN_name"), resources:get("param_LN_description"), 26, 2, 1000);
    indicator.parameters:addInteger("IN", resources:get("param_IN_name"), resources:get("param_IN_description"), 9, 2, 1000);
    indicator.parameters:addGroup("Style");
    indicator.parameters:addColor("MACD_color", resources:get("param_MACD_color_name"), resources:get("param_MACD_color_description"), core.rgb(255, 0, 0));
    indicator.parameters:addInteger("widthMACD", resources:get("param_widthMACD_name"), resources:get("param_widthMACD_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleMACD", resources:get("param_styleMACD_name"), resources:get("param_styleMACD_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleMACD", core.FLAG_LEVEL_STYLE);
    indicator.parameters:addColor("SIGNAL_color", resources:get("param_SIGNAL_color_name"), resources:get("param_SIGNAL_color_description"), core.rgb(0, 0, 255));
    indicator.parameters:addInteger("widthSIGNAL", resources:get("param_widthSIGNAL_name"), resources:get("param_widthSIGNAL_description"), 1, 1, 5);
    indicator.parameters:addInteger("styleSIGNAL", resources:get("param_styleSIGNAL_name"), resources:get("param_styleSIGNAL_description"), core.LINE_SOLID);
    indicator.parameters:setFlag("styleSIGNAL", core.FLAG_LEVEL_STYLE);
    indicator.parameters:addColor("HISTOGRAM_color", resources:get("param_HISTOGRAM_color_name"), resources:get("param_HISTOGRAM_color_description"), core.rgb(0, 255, 0));
end

-- Indicator instance initialization routine
-- Processes indicator parameters and creates output streams
-- Parameters block
local SN;
local LN;
local IN;

local firstPeriodMACD;

local firstPeriodSIGNAL;
local source = nil;

local EMAS = nil;
local EMAL = nil;
local MVAI = nil;

-- Streams block
local MACD = nil;
local SIGNAL = nil;
local HISTOGRAM = nil;

-- Routine
function Prepare()
    SN = instance.parameters.SN;
    LN = instance.parameters.LN;
    IN = instance.parameters.IN;
    source = instance.source;

    -- Check parameters
    if (LN <= SN) then
       error("The short EMA period must be smaller than long EMA period");
    end

    -- Create short and long EMAs for the source
    EMAS = core.indicators:create("EMA", source, SN);
    EMAL = core.indicators:create("EMA", source, LN);

    -- Base name of the indicator.
    local name = profile:id() .. "(" .. source:name() .. ", " .. SN .. ", " .. LN .. ", " .. IN .. ")";
    instance:name(name);

    local precision = math.max(2, source:getPrecision());
    
    -- Create the output stream for the MACD. The first period is equal to the
    -- biggest first period of source EMA streams
    firstPeriodMACD = EMAL.DATA:first();
    MACD = instance:addStream("MACD", core.Line, name .. ".MACD", "MACD", instance.parameters.MACD_color, firstPeriodMACD);
    MACD:setWidth(instance.parameters.widthMACD);
    MACD:setStyle(instance.parameters.styleMACD);
    MACD:setPrecision(precision);

    -- Create MVA for the MACD output stream.
    MVAI = core.indicators:create("MVA", MACD, IN);
    -- Create output for the signal and histogram
    firstPeriodSIGNAL = MVAI.DATA:first();

    SIGNAL = instance:addStream("SIGNAL", core.Line, name .. ".SIGNAL", "SIGNAL", instance.parameters.SIGNAL_color, firstPeriodSIGNAL);
    SIGNAL:setWidth(instance.parameters.widthSIGNAL);
    SIGNAL:setStyle(instance.parameters.styleSIGNAL);
    SIGNAL:setPrecision(precision);
    HISTOGRAM = instance:addStream("HISTOGRAM", core.Bar, name .. ".HISTOGRAM", "HISTOGRAM", instance.parameters.HISTOGRAM_color, firstPeriodSIGNAL);
    HISTOGRAM:setPrecision(precision);
end

-- Indicator calculation routine
function Update(period, mode)
    -- and update short and long EMAs for the source.
    EMAS:update(mode);
    EMAL:update(mode);

    if (period >= firstPeriodMACD) then
        -- calculate MACD output
         MACD[period] = EMAS.DATA[period] - EMAL.DATA[period];
    end

    -- update MVA on the MACD
    MVAI:update(mode);
    if (period >= firstPeriodSIGNAL) then
        SIGNAL[period] = MVAI.DATA[period];
        -- calculate histogram as a difference between MACD and signal
        HISTOGRAM[period] = MACD[period] - SIGNAL[period];
    end
end


