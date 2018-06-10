//using YerbaSoft.Web.JavaScript.Math.js

var $Html = {

    String: {

        GetAttr: function (htmlSection, attr) {
            return $.parseXML(htmlSection).childNodes[0].getAttribute(attr);
        },

        GetInnerHtml: function (htmlSection, tagName) {
            var p = $Html._FindSectionEndHeader(htmlSection);
            return htmlSection.substr(p + 1, htmlSection.length - p - tagName.length - "</>".length - 1);
        }
    },

    FindSection: function (html, p, section_start, section_end) {
        var toFind = html.toLowerCase();
        var ini = toFind.indexOf(section_start, p); ini = ini < 0 ? $Math.LongMaxValue : ini;
        var end = $Math.LongMaxValue;
        if (ini < $Math.LongMaxValue)
            end = this._FindSectionEnd(html, ini + 1, section_start, section_end);
        //var headerEnd = this._FindSectionEndHeader(html);
        
        return { TagStart: ini, TagEnd: end /*, TagHeaderEnd: headerEnd*/ };
    },

    _FindSectionEnd: function (html, p, section_start, section_end) {
        p = p == undefined ? 0 : p;

        var level = 0;
        p++;
        while (level >= 0) {
            var ini = html.indexOf(section_start, p); ini = ini < 0 ? $Math.LongMaxValue : ini;
            var end = html.indexOf(section_end, p); end = end < 0 ? $Math.LongMaxValue : end;

            if (ini == end && ini == $Math.LongMaxValue)
                throw "ERROR! no se encuentra el fin del tag " + section_end;

            if (ini < end) {
                level++;
                p = ini;
            }
            else {
                level--;
                p = end;
            }
            p++;
        }
        return p + section_end.length - 1;
    },

    _FindSectionEndHeader: function (htmlSection) {
        // Busco donde cierra el tag de inicio
        var level = 0;
        for (var p = 1; p < htmlSection.length; p++) {
            if (htmlSection[p] == "\"") {
                if (level == 0)
                    level++;
                else
                    level--;
            }
            else if (htmlSection[p] == ">")
                level--;

            if (level < 0)
                break;
        }
        return level < 0 ? p : -1;
    }
}