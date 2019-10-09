using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.Common.DAL.SP
{
    public class Parameters : List<Parameter>
    {
        internal Oracle.ManagedDataAccess.Client.OracleParameter[] GetOracleParameters(Oracle.ManagedDataAccess.Client.OracleConnection conn)
        {
            var result = new List<Oracle.ManagedDataAccess.Client.OracleParameter>();
            foreach (var p in this)
            {
                if (p.Type == typeof(Guid[]) || p.Type == typeof(string[]))
                {
                    Oracle.ManagedDataAccess.Types.OracleClob clob = null;
                    if (p.Type == typeof(Guid[]) && p.Value != null)
                    {
                        if (conn.State != System.Data.ConnectionState.Open)
                            conn.Open();
                        clob = new Oracle.ManagedDataAccess.Types.OracleClob(conn);
                        var data = string.Join(",", ((Guid[])p.Value).Select(g => g.ToRaw()));
                        clob.Write(data.ToArray(), 0, data.Length);
                    }
                    else if (p.Type == typeof(string[]) && p.Value != null)
                    {
                        if (conn.State != System.Data.ConnectionState.Open)
                            conn.Open();
                        clob = new Oracle.ManagedDataAccess.Types.OracleClob(conn);
                        var data = string.Join(",", (string[])p.Value);
                        clob.Write(data.ToArray(), 0, data.Length);
                    }

                    result.Add(new Oracle.ManagedDataAccess.Client.OracleParameter()
                    {
                        OracleDbType = p.GetOracleType(),
                        Direction = p.IsOutput ? System.Data.ParameterDirection.Output : System.Data.ParameterDirection.Input,
                        ParameterName = p.Name,
                        Value = clob ?? (object)DBNull.Value
                    });
                }
                else
                {
                    result.Add(new Oracle.ManagedDataAccess.Client.OracleParameter()
                    {
                        OracleDbType = p.GetOracleType(),
                        Direction = p.IsOutput ? System.Data.ParameterDirection.Output : System.Data.ParameterDirection.Input,
                        ParameterName = p.Name,
                        Value = CheckOracleValue(p.Value, p.GetOracleType()) ?? (object)DBNull.Value
                    });
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Agrega un parámetro a la lista de parámetros. Ésta funcion devolverá error si el valor es NULL
        /// </summary>
        /// <param name="name">nombre del parámetro</param>
        /// <param name="value">valor del parámetro. No puede ser null</param>
        /// <returns></returns>
        public Parameters AddParam(string name, object value)
        {
            this.Add(new Parameter() { Name = name, Value = value, Type = value.GetType() });
            return this;
        }

        private object CheckOracleValue(object obj, Oracle.ManagedDataAccess.Client.OracleDbType oracleType)
        {
            if (obj == null)
                return obj;

            if (oracleType == Oracle.ManagedDataAccess.Client.OracleDbType.Raw)
                return ((Guid)obj).ToByteArray();

            if (oracleType == Oracle.ManagedDataAccess.Client.OracleDbType.Char && (obj.GetType() == typeof(bool?) || obj.GetType() == typeof(bool)))
                return ((bool?)obj).HasValue ? (((bool?)obj).Value ? 'Y' : 'N') : (char?)null;

            if (oracleType == Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor)
                return null;

            return obj;
        }
    }
}
