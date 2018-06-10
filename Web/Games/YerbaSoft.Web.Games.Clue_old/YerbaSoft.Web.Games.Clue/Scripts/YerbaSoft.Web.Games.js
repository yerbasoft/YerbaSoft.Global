//using YerbaSoft.Web.JavaScript.ControlManager.js

var $Server = {

    Ajax: function (url, data, onsuccess, onerror) {
        $Server.Post(url, data, function (result, e) {
            if (result == null || result.ExistsErrorMessages == true) {
                $Server.Alert(result.Messages[0].Text, document.title, onerror);
                return;
            }
            else {
                if (typeof onsuccess == 'function')
                    onsuccess(result.Data, e);
            }
        }, onerror);
    },
    
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
    },

    Alert: function (message, title, callback, divName) {
        var divName = divName == undefined || divName == null ? "divAlert" : divName;
        var div = $('<div id="' + divName + '" style="display: none;"></div>');
        div.html("<p>" + message + "</p>");

        if (title == undefined)
            title = "YerbaSoft - Games";

        div.dialog({
            show: "slow",
            hide: "explode",
            title: title,
            modal: true,
            close: callback
        });
    },

    Security: {
        CurrentUserId: null,
        CurrentUser: null
    },

    Clue: {
        Mesa: {
            EstadoAbierta: 0,
            EstadoJugando: 1
        }
    }
};