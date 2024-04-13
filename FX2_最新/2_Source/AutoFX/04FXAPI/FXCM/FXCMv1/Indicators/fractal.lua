function Init()
    indicator:name(resources:get("name"));
    indicator:description(resources:get("description"));
    indicator:requiredSource(core.Bar);
    indicator:type(core.Indicator);
    indicator:setTag("group", "Bill Williams");

    indicator.parameters:addColor("clrUP", resources:get("param_clrUp_name"), resources:get("param_clrUp_description"), core.COLOR_UPCANDLE);
    indicator.parameters:addColor("clrDN", resources:get("param_clrDown_name"), resources:get("param_clrDown_description"), core.COLOR_DOWNCANDLE);
    indicator.parameters:addBoolean("ShowPrice", resources:get("param_show_price"), resources:get("param_show_price_1"), false);
    indicator.parameters:addColor("clrPrice", resources:get("param_clrPrice_name"), resources:get("param_clrPrice_description"), core.rgb(128, 128, 128));
end

local source;
local up, down;

function Prepare()
    source = instance.source;
    local name = profile:id() .. "(" .. source:name() .. ")";
    instance:name(name);
    up = instance:createTextOutput ("Up", "Up", "Wingdings", 9, core.H_Center, core.V_Top, instance.parameters.clrUP, 0);
    down = instance:createTextOutput ("Dn", "Dn", "Wingdings", 9, core.H_Center, core.V_Bottom, instance.parameters.clrDN, 0);
    up1 = instance:createTextOutput ("", "UpL", "Verdana", 7, core.H_Right, core.V_Top, instance.parameters.clrPrice, 0);
    down1 = instance:createTextOutput ("", "DnL", "Verdana", 7, core.H_Right, core.V_Bottom, instance.parameters.clrPrice, 0);
end

function Update(period, mode)
    if (period > 6) then
        local curr = source.high[period - 2];
        if (curr > source.high[period - 4] and curr > source.high[period - 3] and
            curr > source.high[period - 1] and curr > source.high[period]) then
            up:set(period - 2, source.high[period - 2], "\217", source.high[period - 2]);
            if instance.parameters.ShowPrice then
                up1:set(period - 2, source.high[period - 2], "  " .. source.high[period - 2]);
            end
        end
        curr = source.low[period - 2];
        if (curr < source.low[period - 4] and curr < source.low[period - 3] and
            curr < source.low[period - 1] and curr < source.low[period]) then
            down:set(period - 2, source.low[period - 2], "\218", source.low[period - 2]);
            if instance.parameters.ShowPrice then
                down1:set(period - 2, source.low[period - 2], "  " .. source.low[period - 2]);
            end
        end
    end
end
