using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Oracle.ManagedDataAccess.Client;

namespace YerbaSoft.Desktop.OracleCloner
{
    public class Connection
    {
        System.Data.IDbConnection con;
        bool GenerateScript;
        bool RunScript;

        public Connection(string cs, bool generateScript, bool runScript)
        {
            this.GenerateScript = generateScript;
            this.RunScript = runScript;
            con = new OracleConnection(cs);
        }

        internal T Get<T>(string sql)
        {
            if (this.GenerateScript)
                Log.Script(sql);

            if (!this.RunScript)
                return default(T);

            T result;

            var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            con.Open();

            if (typeof(T) != typeof(System.Data.DataTable))
            {
                result = (T)YerbaSoft.DTO.Convert.To(typeof(T), cmd.ExecuteScalar());
            }
            else
            {
                var tb = new System.Data.DataTable();
                new OracleDataAdapter((OracleCommand)cmd).Fill(tb);
                result = (dynamic)tb;
            }

            con.Close();

            return result;
        }
    }
}
