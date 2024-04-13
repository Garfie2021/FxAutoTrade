-- Indicator profile initialization routine
-- Defines indicator profile properties and indicator parameters
function Init()
    local i, score;

    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Oscillator);
    indicator:setTag("OnlyMainHistory", "True");
    indicator:setTag("TimeFormatDepend", "True");
    indicator:setTag("IgnoreBidAskChange", "True");
    indicator:setTag("SimulateStrategyParam", "SID");
    indicator:setTag("SimulatorModeParam", "TM");


    indicator.parameters:addGroup(resources:get("group_Signal"));

    indicator.parameters:addString("SID", resources:get("param_SID"), resources:get("param_SID_D"), "MACROSS");
    indicator.parameters:setFlag("SID", 3);
    indicator.parameters:addBoolean("SP", resources:get("param_SP"), resources:get("param_SP_D"), true);

    indicator.parameters:addGroup(resources:get("group_Mode"));

    indicator.parameters:addString("History", resources:get("param_HistoryData"), resources:get("param_HistoryData_D"), "mix");
    indicator.parameters:addStringAlternative("History", resources:get("param_HistoryClose"), "", "close");
    indicator.parameters:addStringAlternative("History", resources:get("param_HistoryHLC"), "", "hlc");
    indicator.parameters:addStringAlternative("History", resources:get("param_HistoryLHC"), "", "lhc");
    indicator.parameters:addStringAlternative("History", resources:get("param_HistoryMix"), "", "mix");

    indicator.parameters:addInteger("TM", resources:get("param_TM"), resources:get("param_TM_Desc"), 0);
    indicator.parameters:addIntegerAlternative("TM", resources:get("param_TM_FIFO"), "", 0);
    indicator.parameters:addIntegerAlternative("TM", resources:get("param_TM_NH"), "", 1);
    indicator.parameters:addIntegerAlternative("TM", resources:get("param_TM_H"), "", 2);

    indicator.parameters:addInteger("Amount", resources:get("param_Amount"), "", 1000000, 1, 1000000000);
    indicator.parameters:addInteger("BaseUnitSize", resources:get("param_baseUnitSize"), "", 10000, 1, 100000);


    indicator.parameters:addGroup(resources:get("group_Output"));
    indicator.parameters:addInteger("LO", resources:get("param_LO"), resources:get("param_LO_D"), 0);
    indicator.parameters:addIntegerAlternative("LO", resources:get("param_YES"), "", 1);
    indicator.parameters:addIntegerAlternative("LO", resources:get("param_NO"), "", 0);

    indicator.parameters:addInteger("FS", resources:get("param_FS"), resources:get("param_FS_D"), 10, 6, 32);
    indicator.parameters:addColor("ACLR", resources:get("param_ACLR"), resources:get("param_ACLR_D"), core.COLOR_LABEL);
    indicator.parameters:addColor("BCLR", resources:get("param_BCLR"), resources:get("param_BCLR_D"), core.COLOR_LABEL);
    indicator.parameters:addColor("SCLR", resources:get("param_SCLR"), resources:get("param_SCLR_D"), core.COLOR_LABEL);
    indicator.parameters:addColor("ECLR", resources:get("param_ECLR"), resources:get("param_ECLR_D"), core.COLOR_LABEL);
end

local score;
local alerts;
local sells;
local buys;
local equity;
local source;
local barsize;
local start = true;
local finished = false;
local baseserial0 = 0;
local baseserialX = 0;
local format;
local canWork = true;

-- Routine
function Prepare(onlyName)
    source = instance.source;

    instance:name(profile:id() .. "(" .. source:name() .. "," .. instance.parameters.SID .. ")");

    if onlyName then
        assert(instance.source:barSize() ~= "t1", resources:get("ERR_TICK"));
        return;
    end

    if instance.source:barSize() == "t1" then
        canWork = false;
    end

    local s, e;
    s, e = core.getcandle(source:barSize(), core.now(), 0);
    barsize = math.floor(e * 86400 - s * 86400 + 0.5);

    sells = instance:createTextOutput("Sell", "Sell", "Wingdings", instance.parameters.FS, core.H_Center, core.V_Top, instance.parameters.SCLR, 0);
    buys = instance:createTextOutput("Buy", "Buy", "Wingdings", instance.parameters.FS, core.H_Center, core.V_Bottom, instance.parameters.BCLR, 0);
    alerts = instance:createTextOutput("Alert", "Alert", "Wingdings", instance.parameters.FS, core.H_Center, core.V_Center, instance.parameters.ACLR, 0);
    equity = instance:addStream("Equity", core.Line, profile:id() .. ".E", "Equity", instance.parameters.ECLR, 0)
    equity:setPrecision(2);
    equity:addLevel(instance.parameters.Amount);
    format = "%s: %.0fK @ %." .. source:getPrecision() .. "f";


    core.host:execute("attachTextToChart", "Alert");
    core.host:execute("attachTextToChart", "Sell");
    core.host:execute("attachTextToChart", "Buy");

    if canWork then
        require("signaltester");

        score = signaltester.getcore();
        score:init(core.app_path(), core.host:execute("getTradingDayOffset"), core.host:execute("getTradingWeekOffset"), instance.parameters.SP, instance.parameters.History, instance.parameters.LO ~= 0);
        core.host:execute("addCommand", 200001, resources:get("CMD_REPO"), resources:get("CMD_REPODESCR"));
    end
end

-- Indicator calculation routine
function Update(period, mode)
    if not(canWork) then
        if period == 0 then
            core.host:execute("setStatus", resources:get("ERR_TICK"));
        end
        return ;
    end

    if finished == true then
        if source:serial(0) ~= baseserial0 then
            -- more data loaded in front of collection. restart!
            finished = false;
            start = true;
        elseif source:serial(source:size() - 1) ~= baseserialX then
            -- just new price appears - only update for the latest data, do not recalc in full!
            if score:continue() == 0 then
                finished = true;
            else
                finished = false;
            end
            baseserialX = source:serial(source:size() - 1);
        end
    end

    if start then
        start = false;

        score:start(instance.parameters.SID, core.host:execute("getBidPrice"), core.host:execute("getAskPrice"), instance.parameters:getCustomParameters("SID"), instance.parameters.TM, instance.parameters.BaseUnitSize, instance.parameters.Amount);
        baseserial0 = source:serial(0);

        if score:continue() == 0 then
            finished = true;
        end
        baseserialX = source:serial(source:size() - 1);
    end

    if finished then
        local i, count, from, to;
        local t;
        from = math.floor(source:date(period) * 86400 + 0.5);
        to = math.floor(source:date(period) * 86400 + 0.5) + barsize;
        count = score:alertCount(period) - 1;
        local msg = "";
        local cnt = 0;
        local firstprice;
        local from;

        for i = 0, count, 1 do
            local instrument, signal, price, time;
            instrument, signal, price, time = score:alert(period, i);
            time = math.floor(time * 86400 + 0.5);
            t = core.dateToTable(core.host:execute("convertTime", 1, 4, time / 86400));
            if cnt == 0 then
                firstprice = price;
            else
                msg = msg .. "\013\010";
            end
            msg = msg .. instrument .. " " .. signal .. "@" .. string.format("%02i/%02i %02i:%02i", t.month, t.day, t.hour, t.min) .. "/" .. price;
            cnt = cnt + 1;
        end

        local char;
        if cnt == 1 then
            char = "\140";
        elseif cnt == 2 then
            char = "\141";
        elseif cnt == 3 then
            char = "\142";
        elseif cnt == 4 then
            char = "\143";
        elseif cnt == 5 then
            char = "\144";
        elseif cnt == 6 then
            char = "\145";
        elseif cnt == 7 then
            char = "\146";
        elseif cnt == 8 then
            char = "\147";
        elseif cnt == 9 then
            char = "\148";
        else
            char = "\164";
        end

        if cnt > 0 then
            alerts:set(period, firstprice, char, msg);
        end

        local buy, buyprice, sell, sellprice, eq;

        buy, buyprice, sell, sellprice, eq = score:tradeInfo(period);
        if (eq ~= nil) then
            equity[period] = eq;
            if buy > 0 then
                buys:set(period, buyprice, "\225", string.format(format, "buy", buy, buyprice));
            end
            if sell > 0 then
                sells:set(period, sellprice, "\226", string.format(format, "sell", sell, sellprice));
            end
        end
    end
end

function AsyncOperationFinished(cookie)
    if cookie == 200001 then
        if finished then
            score:report(resources);
        end
        return ;
    end


    local continue = false;
    local rc;

    continue = score:notifyFinished(cookie);

    if continue then
            rc = score:continue();

            if rc == 0 then
                finished = true;

                -- show result
                instance:updateFrom(0);
            end
    end
end
