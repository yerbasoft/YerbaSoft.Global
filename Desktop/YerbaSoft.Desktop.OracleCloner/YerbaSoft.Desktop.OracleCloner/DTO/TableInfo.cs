using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.OracleCloner.DTO
{
    public class TableInfo
    {
        public string Schema { get; set; }
        public string Name { get; set; }

        public IEnumerable<ColumnInfo> Columns { get; set; }
        public List<Constraint> Constraints { get; set; }

        public Constraint PrimaryKey { get { return this.Constraints.SingleOrDefault(p => p.Type == "P"); } }
    }

    public class ColumnInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long? Length { get; set; }
        public long? Precision { get; internal set; }
        public long? Scale { get; internal set; }
        public bool Nullable { get; set; }
        public object Default { get; set; }
        public long? CharLength { get; internal set; }

        public string LengthToShow
        {
            get
            {
                if (YerbaSoft.DTO.Math.In(Type, new string[] { "RAW" }))
                    return $"({Length})";
                else if (YerbaSoft.DTO.Math.In(Type, new string[] { "VARCHAR", "VARCHAR2", "CHAR", "NVARCHAR", "NVARCHAR2" }))
                    return $"({CharLength ?? Length})";
                else if (YerbaSoft.DTO.Math.In(Type, new string[] { "NUMBER" }))
                    return $"({Precision ?? Length},{Scale ?? 0})";
                else
                    return "";
            }
        }

        internal string GetHash()
        {
            return $"{Name}-{Type}-{LengthToShow}-{Nullable}-{Default}-{CharLength}";
        }
    }

    public class Constraint
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Columns { get; set; }
        public List<Column> RemoteColumns { get; set; }

        internal string GetHash()
        {
            return $"{Name}-{Type}-{string.Join(".", Columns)}";
        }
    }

    public class Column
    {
        public string Schema { get; set; }
        public string Tabla { get; set; }
        public string Name { get; set; }
    }
}
