//using YerbaSoft.Web.JavaScript.Math.js
//using YerbaSoft.Web.JavaScript.Html.js

var TemplateManager = {

    _TemplateStr: "",

    /// <Summary>
    /// Carga el Template (en string) en el TemplateManager como template default
    /// <Summary>
    LoadFromString : function(string) { this._TemplateStr = string; },

    /// <Summary>
    /// Carga el Template (como objeto jQuery de HTML) en el TemplateManager como template default
    /// <Summary>
    LoadFromObject : function(jqObj) { this._TemplateStr = jqObj[0].outerHTML; },

    /// <Summary>
    /// Resuelve el Template con los datos provistos y devuelve el string HTML
    /// <Summary>
    /// <param name="data">objeto de donde se obtendrán los datos para completar el template</param>
    /// <param name="templateStr">[Optional] Template en formato string a procesar. De no especificarse se utilizará el template por default</param>
    ResolveTemplate : function(data, templateStr) {
        if (templateStr === null || templateStr === undefined)
            templateStr = this._TemplateStr;

        return this.prototipe._ResolveTemplate(data, templateStr);
    },

    prototipe: {


        /// <Summary>
        /// Resuelve el Template con los datos provistos y devuelve el string HTML
        /// <Summary>
        /// <param name="Model">objeto de donde se obtendrán los datos para completar el template</param>
        /// <param name="templateStr">Objeto JQuery que contiene el HTML del template</param>
        /// <param name="vars">variables internas</param>
        _ResolveTemplate: function (Model, html, vars) {
            if (vars === undefined)
                vars = [];


            while(true) {
                var simbolo = this._BuscarPrimerSimbolo(html);
                if (simbolo.type == "none") break;
                
                var section = html.substr(simbolo.index, simbolo.indexEnd - simbolo.index);

                var newSectionValue = section;
                if (simbolo.type == "foreach")  newSectionValue = this.__ProcesarSimboloForEach(section, Model, vars);
                if (simbolo.type == "if")       newSectionValue = this.__ProcesarSimboloIf(section, Model, vars);
                if (simbolo.type == "din")      newSectionValue = this.__ProcesarSimboloDin(section, Model, vars);
                if (simbolo.type == "var")      newSectionValue = this.__ProcesarSimboloVar(section, Model, vars);

                html = html.replace(section, newSectionValue);
            }

            return html;
        },

        /// <Summary>
        /// Busca símbolos conocidos en un html y devuelve una estructura con la información encontrada.
        /// <Summary>
        /// <return>Estructura con datos de lo que se encontró
        /// { 
        ///     type: "none" || "foreach" || "if" || "din" || "var" (tipo de elemento que se encontró)
        ///     index: índice donde se encuentra el inicio del símbolo
        ///     indexEnd: índice donde termina el tag del símbolo
        /// }
        /// </return>
        _BuscarPrimerSimbolo : function(html) {
            var toFind = html.toLowerCase();
            var __for = $Html.FindSection(toFind, 0, "<foreach ", "</foreach>"); // toFind.indexOf("<foreach "); __for = __for < 0 ? this.LongMaxValue : __for;
            var __if = $Html.FindSection(toFind, 0, "<if ", "</if>");
            var __din = $Html.FindSection(toFind, 0, "{{", "}}");
            var __var = $Html.FindSection(toFind, 0, "<var ", "/>");

            var result = { type: "none" };

            if (__for.TagStart != $Math.LongMaxValue && $Math.isMinor(__for.TagStart, [__if.TagStart, __din.TagStart, __var.TagStart]))
                result = { type: "foreach", index: __for.TagStart, indexEnd: __for.TagEnd };

            if (__if.TagStart != $Math.LongMaxValue && $Math.isMinor(__if.TagStart, [__for.TagStart, __din.TagStart, __var.TagStart]))
                result = { type: "if", index: __if.TagStart, indexEnd: __if.TagEnd };

            if (__din.TagStart != $Math.LongMaxValue && $Math.isMinor(__din.TagStart, [__for.TagStart, __if.TagStart, __var.TagStart]))
                result = { type: "din", index: __din.TagStart, indexEnd: __din.TagEnd };

            if (__var.TagStart != $Math.LongMaxValue && $Math.isMinor(__var.TagStart, [__for.TagStart, __if.TagStart, __din.TagStart]))
                result = { type: "var", index: __var.TagStart, indexEnd: __var.TagEnd };

            return result;
        },


        /// <Summary>
        /// Resuelve el Simbolo ForEach (repetir el contenido según una enumeración)
        /// <Summary>
        /// <param name="html">html que contiene el ForEach</param>
        /// <param name="Model">objeto de donde se obtendrán los datos para completar el template</param>
        /// <param name="vars">variables internas</param>
        __ProcesarSimboloForEach : function (html, Model, vars) {

            //Seteo en memoria los valores de las variables
            for (var __i = 0; __i < vars.length; __i++)
                eval("var " + vars[__i].name + " = " + JSON.stringify(vars[__i].value) + ";");
            
            var __var_name = $Html.String.GetAttr(html, "var");
            var __inCollection = $Html.String.GetAttr(html, "in");
            var __collection = [];
            eval("__collection = " + __inCollection + ";");

            var __content = "";
            if (__collection != null) {
                for (var __e = 0; __e < __collection.length; __e++) {
                    this.__SetVarValue(vars, __var_name, __collection[__e]);

                    __content += this._ResolveTemplate(Model, $Html.String.GetInnerHtml(html, "foreach"), vars);
                }
            }
            
            return __content;
        },

        /// <Summary>
        /// Resuelve el Simbolo IF (mostrar un contenido según una condición)
        /// <Summary>
        /// <param name="html">html que contiene el ForEach</param>
        /// <param name="Model">objeto de donde se obtendrán los datos para completar el template</param>
        /// <param name="vars">variables internas</param>
        __ProcesarSimboloIf: function (html, Model, vars) {

            //Seteo en memoria los valores de las variables
            for (var __i = 0; __i < vars.length; __i++)
                eval("var " + vars[__i].name + " = " + JSON.stringify(vars[__i].value) + ";");

            var __condition = $Html.String.GetAttr(html, "condicion");
            var __result = false;
            eval("__result = " + __condition + ";");
            
            var fullContent = $Html.String.GetInnerHtml(html, "if");
            var ifContent = fullContent.indexOf("<else />") >= 0 ? fullContent.substr(0, fullContent.indexOf("<else />")) : fullContent;
            var elseContent = fullContent.indexOf("<else />") >= 0 ? fullContent.substr(fullContent.indexOf("<else />") + "<else />".length) : "";

            var __content = (__result) ? ifContent : elseContent;

            return __content;
        },

        /// <Summary>
        /// Resuelve el Simbolo VAR (Agrega o setea el valor de una variable)
        /// <Summary>
        /// <param name="html">html que contiene el ForEach</param>
        /// <param name="Model">objeto de donde se obtendrán los datos para completar el template</param>
        /// <param name="vars">variables internas</param>
        __ProcesarSimboloVar: function (html, Model, vars) {

            //Seteo en memoria los valores de las variables
            for (var __i = 0; __i < vars.length; __i++)
                eval("var " + vars[__i].name + " = " + JSON.stringify(vars[__i].value) + ";");
            
            if (html == "")
            {
                debugger;
                return "";
            }
            var __name = $Html.String.GetAttr(html, "name");
            var __value = $Html.String.GetAttr(html, "value");

            var __result = false;
            eval("__result = " + __value + ";");

            this.__SetVarValue(vars, __name, __result);

            return "";  // la asignación de variables no devuelve nada en HTML
        },

        /// <Summary>
        /// Resuelve el Simbolo DIN (ejecuta un javascript (o nombre de una variable) y devuelve el resultado)
        /// <Summary>
        /// <param name="html">html que contiene el ForEach</param>
        /// <param name="Model">objeto de donde se obtendrán los datos para completar el template</param>
        /// <param name="vars">variables internas</param>
        __ProcesarSimboloDin: function (html, Model, vars) {

            //Seteo en memoria los valores de las variables
            for (var __i = 0; __i < vars.length; __i++)
                eval("var " + vars[__i].name + " = " + JSON.stringify(vars[__i].value) + ";");

            var __content = html.substr("{{".length, html.length - "{{}}".length);
            var __result = "";
            eval("__result = " + __content + ";");

            return __result;
        },


        /// <Summary>
        /// Establece un valor a una variable interna
        /// <Summary>
        /// <param name="vars">array de variables internas</param>
        /// <param name="name">nombre de la variable</param>
        /// <param name="value">valor para la variable</param>
        __SetVarValue : function(vars, name, value){
            var founded = false;
            for(var __i = 0; __i < vars.length; __i++) {
                if (vars[__i].name == name)
                {
                    vars[__i].value = value;
                    founded = true;
                    break;
                }
            }
            if (!founded)
                vars[vars.length] = { name: name, value: value };

            return vars;
        }
    }
}