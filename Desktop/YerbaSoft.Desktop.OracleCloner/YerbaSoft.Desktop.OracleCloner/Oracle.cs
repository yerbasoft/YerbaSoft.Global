using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.OracleCloner.DTO;

namespace YerbaSoft.Desktop.OracleCloner
{
    public class Oracle
    {
        private Connection con;
        public Oracle(string cs, bool generateScript, bool runScript)
        {
            con = new Connection(cs, generateScript, runScript);
        }

        public bool ExistsSchema(string schema)
        {
            return (con.Get<int?>($"SELECT 1 FROM dba_users WHERE USERNAME = '{schema}'") ?? 0) > 0;
        }

        internal void CreateSchema(string schema)
        {
            con.Get<object>($"CREATE USER {schema} IDENTIFIED BY \"Ab123456\"");
        }

        internal IEnumerable<string> GetTables(string schema)
        {
            var data = con.Get<DataTable>($"SELECT TABLE_NAME FROM ALL_TABLES WHERE OWNER = '{schema}'");

            return data.Rows.OfType<DataRow>().Select(p => (p[0] ?? "").ToString());
        }

        internal bool ExistsTabla(string schema, string tabla)
        {
            return (con.Get<int?>($"SELECT 1 FROM ALL_TABLES WHERE OWNER = '{schema}' AND TABLE_NAME = '{tabla}'") ?? 0) > 0;
        }

        internal TableInfo GetTableInfo(string schema, string tabla)
        {
            var info = new TableInfo() { Schema = schema, Name = tabla };

            var data = con.Get<DataTable>($"SELECT COLUMN_NAME, DATA_TYPE, DATA_LENGTH, NULLABLE, DATA_DEFAULT, DATA_PRECISION, DATA_SCALE, CHAR_LENGTH FROM ALL_TAB_COLUMNS WHERE OWNER = '{schema}' AND TABLE_NAME = '{tabla}'");
            info.Columns = data.Rows.OfType<DataRow>().Select(p => new ColumnInfo()
            {
                Name = (p[0] ?? "").ToString(),
                Type = (p[1] ?? "").ToString(),
                Length = p[2] == DBNull.Value ? (long?)null : Convert.ToInt64(p[2]),
                Nullable = (p[3] ?? "").ToString() == "Y",
                Default = p[4],
                Precision = p[5] == DBNull.Value ? (long?)null : Convert.ToInt64(p[5]),
                Scale = p[6] == DBNull.Value ? (long?)null : Convert.ToInt64(p[6]),
                CharLength = p[7] == DBNull.Value ? (long?)null : Convert.ToInt64(p[7])
            });

            // Constraints
            data = con.Get<DataTable>(  $"SELECT  cons.constraint_name, " +
                                        $"        cons.constraint_type, " +
                                        $"        cols.column_name, " +
                                        $"        cons.R_OWNER, " +
                                        $"        (SELECT rcol.table_name FROM all_cons_columns rcol WHERE rcol.owner = cons.R_OWNER AND rcol.constraint_name = cons.R_CONSTRAINT_NAME AND rcol.position = cols.position ), " +
                                        $"        (SELECT rcol.column_name FROM all_cons_columns rcol WHERE rcol.owner = cons.R_OWNER AND rcol.constraint_name = cons.R_CONSTRAINT_NAME AND rcol.position = cols.position ) " +
                                        $"FROM    all_constraints cons, all_cons_columns cols " +
                                        $"WHERE   cols.table_name = '{tabla}' AND cols.OWNER = '{schema}' " +
                                        $"AND     cons.constraint_type IN( 'P', 'R' ) " +
                                        $"AND     cons.constraint_name = cols.constraint_name " +
                                        $"AND     cons.owner = cols.owner " +
                                        $"AND     cons.status = 'ENABLED' " +
                                        $"ORDER BY cons.constraint_name, cols.position");

            info.Constraints = new List<DTO.Constraint>();
            foreach (var row in data.Rows.OfType<DataRow>())
            {
                var name = (row[0] ?? "").ToString();

                if (!info.Constraints.Any(p => p.Name == name))
                    info.Constraints.Add(new DTO.Constraint() { Name = name, Columns = new List<string>(), RemoteColumns = new List<Column>() });

                var c = info.Constraints.Single(p => p.Name == name);

                c.Type = (row[1] ?? "").ToString();
                c.Columns.Add((row[2] ?? "").ToString());
                if (row[5] != DBNull.Value)
                    c.RemoteColumns.Add(new Column() { Schema = (row[3] ?? "").ToString(), Tabla = (row[4] ?? "").ToString(), Name = (row[5] ?? "").ToString() });
            }

            return info;
        }

        internal void CreateTabla(TableInfo tbl)
        {
            var cols = string.Join(",", tbl.Columns.Select(p => $"{p.Name} {p.Type}{p.LengthToShow} {(p.Nullable ? "NULL" : "NOT NULL")} "));
            con.Get<object>($"CREATE TABLE {tbl.Schema}.{tbl.Name} ( {cols} )");
        }

        internal void AlterColumn(string schema, string tabla, ColumnInfo col)
        {
            var add = $"{col.Name} {col.Type}{col.LengthToShow} {(col.Nullable ? "NULL" : "NOT NULL")}";
            con.Get<object>($"ALTER TABLE {schema}.{tabla} MODIFY {add}");
        }

        internal void CreateColumn(string schema, string tabla, ColumnInfo col)
        {
            var add = $"{col.Name} {col.Type}{col.LengthToShow} {(col.Nullable ? "NULL" : "NOT NULL")}";
            con.Get<object>($"ALTER TABLE {schema}.{tabla} ADD {add}");
        }

        internal void DropColumn(string schema, string tabla, string column)
        {
            con.Get<object>($"ALTER TABLE {schema}.{tabla} DROP COLUMN {column}");
        }


        internal void CreateConstraint(string schema, string tabla, DTO.Constraint cons)
        {
            if (cons.Type == "P")
                con.Get<object>($"ALTER TABLE {schema}.{tabla} ADD CONSTRAINT {cons.Name} PRIMARY KEY ( {string.Join(", ", cons.Columns)} )");
            else
                con.Get<object>($"ALTER TABLE {schema}.{tabla} ADD CONSTRAINT {cons.Name} FOREIGN KEY ( {string.Join(", ", cons.Columns)} ) REFERENCES {cons.RemoteColumns[0].Schema}.{cons.RemoteColumns[0].Tabla} ( {string.Join(", ", cons.RemoteColumns.Select(p => p.Name))} )");
        }

        internal void DropConstraint(string schema, string tabla, string cons)
        {
            con.Get<object>($"ALTER TABLE {schema}.{tabla} DROP CONSTRAINT {cons}");
        }

    }
}
