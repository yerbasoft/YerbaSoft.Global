using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.SP
{
    /// <summary>
    /// Interfaz con métodos para la ejecución de procedimientos almacenados
    /// </summary>
    public interface IExecProcedurable
    {
        /// <summary>
        /// Ejecuta un procedimiento almacenado en la DB y devuelve el resultado casteado a IList<T>
        /// </summary>
        /// <typeparam name="T">Clase de tipo de retorno</typeparam>
        /// <param name="name">Nombre del SP</param>
        /// <param name="parametros">Parámetros a enviar al SP</param>
        /// <returns>Lista de resultados del SP casteado a T</returns>
        IList<T> ExecProcedure<T>(string name, SP.Parameters parametros) where T : new();
        /// <summary>
        /// Ejecuta un procedimiento almacenado en la DB y devuelve el resultado casteado a IList<T>
        /// </summary>
        /// <typeparam name="T">Clase de tipo de retorno</typeparam>
        /// <param name="name">Nombre del SP</param>
        /// <param name="parametros">Parámetros a enviar al SP</param>
        /// <param name="count">Cantidad de registros obtenidos. O bien, valor de la columna "C__" (para totalizadores en caso de paginación)</param>
        /// <param name="timeTicks">Tiempo en Ticks que duró la ejecución del SP</param>
        /// <returns>Lista de resultados del SP casteado a T</returns>
        IList<T> ExecProcedure<T>(string name, SP.Parameters parametros, out int count, out long timeTicks) where T : new();
    }
}
