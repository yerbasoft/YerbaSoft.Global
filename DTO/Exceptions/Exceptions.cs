using System.Collections.Generic;

namespace YerbaSoft.DTO.Exceptions
{
    /// <summary>
    /// Clase Helper para el manejo de Excepciones
    /// </summary>
    public class Exceptions
    {
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex)
        {
            return GetErrorFullDescription(ex, null, new ExceptionConvertTemplateFull());
        }
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <param name="values">lista de valores adicionales</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex, Dictionary<string, object> values)
        {
            return GetErrorFullDescription(ex, values, new ExceptionConvertTemplateFull());
        }
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <param name="config">Template y configuración del mismo</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex, ExceptionConvertTemplateBase config)
        {
            return GetErrorFullDescription(ex, null, config);
        }
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <param name="value">único valor para la lista de valores adicionales</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex, KeyValuePair<string, object> value)
        {
            var values = new Dictionary<string, object>();
            values.Add(value.Key, value.Value);
            return GetErrorFullDescription(ex, values, new ExceptionConvertTemplateFull());
        }
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <param name="value">único valor para la lista de valores adicionales</param>
        /// <param name="config">Template y configuración del mismo</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex, KeyValuePair<string, object> value, ExceptionConvertTemplateBase config)
        {
            var values = new Dictionary<string, object>();
            values.Add(value.Key, value.Value);
            return GetErrorFullDescription(ex, values, config);
        }
        /// <summary>
        /// Devuelve un texto descriptivo de una excepción
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <param name="values">lista de valores adicionales</param>
        /// <param name="config">Template y configuración del mismo</param>
        /// <returns></returns>
        public static string GetErrorFullDescription(System.Exception ex, Dictionary<string, object> values, ExceptionConvertTemplateBase config)
        {
            if (ex == null)
                return null;

            values = Convert.IsNull(values, new Dictionary<string, object>());
            config = Convert.IsNull(config, new ExceptionConvertTemplateFull());


            return config.GetFullDescription(ex, values);
        }
    }
}
