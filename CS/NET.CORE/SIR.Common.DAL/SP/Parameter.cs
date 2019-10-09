using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.SP
{
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
        internal bool IsOutput { get; set; }

        internal Oracle.ManagedDataAccess.Client.OracleDbType GetOracleType()
        {
            if (this.Type == typeof(Guid[]) || this.Type == typeof(string[]))
                return Oracle.ManagedDataAccess.Client.OracleDbType.Clob;

            switch (Type.IsGenericType ? Type.GenericTypeArguments[0].FullName : Type.FullName)
            {
                case "System.DateTime":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Date;
                case "System.Boolean":
                case "System.Char":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Char;
                case "System.Guid":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Raw;
                case "System.Int16":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Int16;
                case "System.Int32":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Int32;
                case "System.Int64":
                case "System.Decimal":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Decimal;
                case "System.String":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2;
                case "System.Data.DataTable":
                    return Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor;
                default:
                    return Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2;
            }
        }
    }
}
