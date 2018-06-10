var ControlManager = {

    /// Convierte un TextBox a un Label (Enabled = false)
    ConvertTextToLabel: function (objText) {
        $(objText).attr('type', 'Hidden');

        var label = '<label class="form-control" style="color: #999; font-weight: 400; max-width: 280px;" for="Login">{TEXTO}</label>'
        label = label.replace("{TEXTO}", $(objText).val());
        $(label).insertAfter($(objText));
    }
    
};

var $Ajax = {

    Post: function (url, data, onsuccess, onerror) {
        var start = new Date();
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (e) { if (typeof onsuccess == "function") { onsuccess(e, { timeLapsed: GetPing(start) }); } },
            error: function (e) { if (typeof onerror == "function") onerror(e, data); }
        });
    }
};

function GetPing(fecha) {
    var now = new Date();
    var _now = now.getUTCMilliseconds() + now.getUTCSeconds() * 1000 + now.getMinutes() * 1000 * 60;
    var _date = fecha.getUTCMilliseconds() + fecha.getUTCSeconds() * 1000 + fecha.getMinutes() * 1000 * 60;

    return _now - _date;
}
