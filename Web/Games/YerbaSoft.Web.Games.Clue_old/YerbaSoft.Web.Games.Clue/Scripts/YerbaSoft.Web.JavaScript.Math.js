var $Math = {
    
    LongMinValue: -9007199254740990,
    LongMaxValue: 9007199254740990,

    NewGuid: function() {
        function s4() { return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1); }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
    },

    /// <summary>
    /// Indica si un valor es el menor de una lista de valores
    /// <summary>
    isMinor: function (value, values) {
        if (values == undefined)
            return true;

        for (var i = 0; i <= values.length; i++) {
            if (value > values[i])
                return false;
        }

        return true;
    },

    /// <summary>
    /// Indica si un valor es el menor de una lista de valores
    /// <summary>
    isMayor: function (value, values) {
        if (values == undefined)
            return true;

        for (var i = 0; i <= values.length; i++) {
            if (value < values[i])
                return false;
        }

        return true;
    },

    /* Devuelve un número entero random entre 2 números */
    Rnd: function(min, max) {
        min = min ? min : $Math.LongMinValue;
        max = max ? max : $Math.LongMaxValue;
        return Math.floor(Math.random() * (max - min + 1)) + min;
    },

    /// <summary>
    /// Funciones de Array
    /// <summary>
    Array: {

        /// <summary>
        /// Busca items en un Array según el criterio de búsqueda
        /// <summary>
        /// <param name="array">Array de datos</param>
        /// <param name="condition"> Condición en la que se quiere buscar, pueden ser distintos tipos:
        ///     function(item): función que deve devolver true/false, se ejecutará por cada item del array y se enviará el item como parámetro
        ///     string: se ejecutará el string por cada item como javascript y se evaluará si el retorno es true (el parámetro "item" será el item en el array)
        ///     otro tipo de dato (incluye string): se evalúa si se encuentra el dato en el array (item == condition)
        /// </param>
        /// <returns>Array de items encontrados</returns>
        find: function (array, condition) {
            var res = [];
            for (var i = 0; i < (array ? array.length : -1) ; i++) {
                if (this.prototype.__ResolveCondition(array[i], condition))
                    res[res.length] = array[i];
            }
            return res;
        },
        
        /// <summary>
        /// Busca el primer item que cumpla el criterio de búsqueda
        /// <summary>
        /// <param name="array">Array de datos</param>
        /// <param name="condition"> Condición en la que se quiere buscar, pueden ser distintos tipos:
        ///     function(item): función que deve devolver true/false, se ejecutará por cada item del array y se enviará el item como parámetro
        ///     string: se ejecutará el string por cada item como javascript y se evaluará si el retorno es true (el parámetro "item" será el item en el array)
        ///     otro tipo de dato (incluye string): se evalúa si se encuentra el dato en el array (item == condition)
        /// </param>
        /// <returns>item encontrado</returns>
        findFirst: function(array, condition) {
            for (var i = 0; i < (array ? array.length : -1) ; i++) {
                if (this.prototype.__ResolveCondition(array[i], condition))
                    return array[i];
            }
            return null;
        },

        /// <summary>
        /// Borra los items que cumplan la condición de un array y devuelve el nuevo array
        /// <summary>
        /// <param name="array">Array de datos</param>
        /// <param name="condition"> Condición en la que se quiere buscar, pueden ser distintos tipos:
        ///     function(item): función que deve devolver true/false, se ejecutará por cada item del array y se enviará el item como parámetro
        ///     string: se ejecutará el string por cada item como javascript y se evaluará si el retorno es true (el parámetro "i" será el índice del array)
        ///     otro tipo de dato (incluye string): se evalúa si se encuentra el dato en el array (item == condition)
        /// </param>
        /// <returns>Elemento del Array</returns>
        remove: function(array, condition) {
            var res = [];
            for (var i = 0; i < (array ? array.length : -1) ; i++) {
                if (!this.prototype.__ResolveCondition(array[i], condition))
                    res[res.length] = array[i];
            }
            return res;
        },

        prototype: {

            /// <summary>
            /// Resuelve una condición genérica sobre un item y devuelve true/false si se cumple
            /// <summary>
            /// <param name="item">Item sobre el que se hace la comparación</param>
            /// <param name="condition"> Condición en la que se quiere buscar, pueden ser distintos tipos:
            ///     function(item): función que deve devolver true/false, se ejecutará por cada item del array y se enviará el item como parámetro
            ///     string: se ejecutará el string por cada item como javascript y se evaluará si el retorno es true (el parámetro "i" será el índice del array)
            ///     otro tipo de dato (incluye string): se evalúa si se encuentra el dato en el array (item == condition)
            /// </param>
            /// <returns>true/false</returns>
            __ResolveCondition: function (item, condition) {
                
                if (condition == item)
                    return true;

                else if (typeof condition == 'function' && condition(item))
                    return true;

                else if (typeof condition == 'string') {
                    var __eval = false;
                    eval("try { __eval = " + condition + "; } catch(__err) { }");
                    if (__eval) return true;
                }
                    
                return false;
            }

        }
    }
}