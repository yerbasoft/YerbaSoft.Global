using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.SP
{
    internal class StoredProcedure : IExecProcedurable
    {
        private OracleConnection dbConnection { get; set; }

        public StoredProcedure(string connectionString)
        {
            dbConnection = new OracleConnection(connectionString);
        }

        public IList<T> ExecProcedure<T>(string name, Parameters parametros) where T : new() => ExecProcedure<T>(name, parametros, out _, out _);
        public IList<T> ExecProcedure<T>(string name, Parameters parametros, out int count, out long timeTicks) where T : new()
        {
            return Executer.ExecProcedure<T>(dbConnection, name, parametros, out count, out timeTicks);
        }
    }
}
