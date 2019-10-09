using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.Common.DAL.SP
{
    internal static class Executer
    {
        internal static IList<T> ExecProcedure<T>(OracleConnection dbConnection, string name, Parameters parametros, out int count, out long timeTicks) where T : new()
        {
            parametros = parametros ?? new Parameters();
            var result = new List<T>();
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = name;
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                // Parámetros
                foreach (var p in parametros.GetOracleParameters(dbConnection))
                    dbCommand.Parameters.Add(p);
                dbCommand.Parameters.Add(new OracleParameter() { ParameterName = "CRESULT", Direction = System.Data.ParameterDirection.Output, OracleDbType = OracleDbType.RefCursor });

                if (dbConnection.State != System.Data.ConnectionState.Open)
                    dbConnection.Open();

                var reader = dbCommand.ExecuteReader();

                // Levanto la configuración de columnas de salida
                var cols = new Dictionary<int, System.Reflection.PropertyInfo>();

                int? existCount = null;
                for (var c = 0; c < reader.FieldCount; c++)
                {
                    var fieldName = reader.GetName(c);
                    var prop = typeof(T).GetProperties().Where(p => p.Name.ToUpper() == fieldName.ToUpper() && p.CanWrite).SingleOrDefault();

                    if (prop != null)
                        cols.Add(c, prop);

                    if (fieldName == "C__")
                        existCount = c;
                }

                // ejecuto y completo armo el resultado
                count = 0;
                timeTicks = 0;
                var timeIni = DateTime.Now.Ticks;
                while (reader.Read())
                {
                    if (timeTicks == 0)
                        timeTicks = DateTime.Now.Ticks - timeIni;

                    var row = new T();

                    if (existCount.HasValue)
                        if (count == 0) { count = reader.GetInt32(existCount.Value); }
                        else
                            count++;

                    foreach (var c in cols)
                        c.Value.SetValue(row, CheckOracleValue(reader.GetValue(c.Key), c.Value.PropertyType));

                    result.Add(row);
                }
            }

            dbConnection.Close();

            return result;
        }

        private static object CheckOracleValue(object value, Type type)
        {
            if (value == null) return value;

            value = IsNull(value, null);
            if (type == typeof(System.Guid) || type == typeof(System.Guid?))    // trato especial con los GUID
                value = value == null ? (Guid?)null : new Guid((byte[])value);
            if (type == typeof(System.Decimal) || type == typeof(System.Decimal?))
                value = value == null ? (Decimal?)null : Convert.ToDecimal(value);
            if (type == typeof(System.Int64) || type == typeof(System.Int64?))
                value = value == null ? (Int64?)null : Convert.ToInt64(value);
            if (type == typeof(System.Int32) || type == typeof(System.Int32?))
                value = value == null ? (Int32?)null : Convert.ToInt32(value);
            if (type == typeof(System.Int16) || type == typeof(System.Int16?))
                value = value == null ? (Int16?)null : Convert.ToInt16(value);
            if (type == typeof(System.DateTime) || type == typeof(System.DateTime?))
                value = value == null ? (DateTime?)null : ((DateTime)value == DateTime.MinValue ? null : value);
            if (type == typeof(System.String))
                value = value == null ? null : value.ToString();
            if (type == typeof(Boolean) || type == typeof(Boolean?))
                value = value == null ? (bool?)null : (((string)value == "S" || (string)value == "Y") ? true : false);
            if (type == typeof(System.Data.DataTable))
                value = null;

            return value;
        }

        private static object IsNull(object obj, object isNullValue)
        {
            if (obj == null || obj == DBNull.Value)
                return isNullValue;
            return obj;
        }
    }
}
