using Oracle.ManagedDataAccess.Client;
using SIR.Common.DAL.SP;
using System;
using System.Collections.Generic;

namespace SIR.Common.DAL
{
    public class SimpleDAO : IDAO
    {
        private OracleConnection dbConnection { get; set; }

        public SimpleDAO(string connectionString)
        {
            dbConnection = new OracleConnection(connectionString);
        }

        /// <summary>
        /// Ejecuta un StoredProcedure y devuelve la lista de resultados
        /// </summary>
        /// <typeparam name="T">Tipo de retorno que tendrá el SP</typeparam>
        /// <param name="name">nombre del SP</param>
        /// <param name="parametros">parámetros del SP</param>
        public IList<T> ExecProcedure<T>(string name, Parameters parametros) where T : new() => SP.Executer.ExecProcedure<T>(dbConnection, name, parametros, out _, out _);
        /// <summary>
        /// Ejecuta un StoredProcedure y devuelve la lista de resultados
        /// </summary>
        /// <typeparam name="T">Tipo de retorno que tendrá el SP</typeparam>
        /// <param name="name">nombre del SP</param>
        /// <param name="parametros">parámetros del SP</param>
        /// <param name="count">Cantidad de registros devueltos (En caso de existir la columna "C__" se muestra ése valor</param>
        /// <param name="timeTicks">Tiempo en Ticks que se demoró la ejecución del SP</param>
        public IList<T> ExecProcedure<T>(string name, Parameters parametros, out int count, out long timeTicks) where T : new() => SP.Executer.ExecProcedure<T>(dbConnection, name, parametros, out count, out timeTicks);

        /// <summary>
        /// Obtiene una configuración de la tabla principal de configuraciones
        /// </summary>
        /// <param name="module">nombre del módulo que contiene la configuración</param>
        /// <param name="key">nombre de la Key de la configuración</param>
        /// <returns></returns>
        public string GetConfig(string module, string key)
        {
            string result = null;
            using (var dbCommand = dbConnection.CreateCommand())
            {
                string debug = "AND DEBUG = 0 ";
#if DEBUG
                debug = "";
#endif

                dbCommand.CommandText = $@"SELECT   VALUE
                                           FROM     SIR.CONFIG 
                                           WHERE    MODULEID = '{module}' AND KEY = '{key}' {debug}
                                           ORDER BY DEBUG DESC";
                dbCommand.CommandType = System.Data.CommandType.Text;

                if (dbConnection.State != System.Data.ConnectionState.Open)
                    dbConnection.Open();

                result = (string)dbCommand.ExecuteScalar();

                dbConnection.Close();
            }

            return result;
        }

        public void BeginTran() { }
        public void Commit() { }
        public void Rollback() { }
    }
}
