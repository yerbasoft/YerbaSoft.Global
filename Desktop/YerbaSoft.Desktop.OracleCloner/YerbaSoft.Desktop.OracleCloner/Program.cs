using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.OracleCloner
{
    class Program
    {
        private static string[] Schemas { get; set; }
        private static Oracle Origen { get; set; }
        private static Oracle Destino { get; set; }

        private static FourList<string, string, DTO.TableInfo, DTO.TableInfo> Tables;

        static void Main(string[] args)
        {
            Tables = new FourList<string, string, DTO.TableInfo, DTO.TableInfo>();

            var GenerateScript = Convert.ToBoolean(ConfigurationManager.AppSettings["script"]);
            var RunScript = Convert.ToBoolean(ConfigurationManager.AppSettings["run"]);
            Schemas = ConfigurationManager.AppSettings["schemas"].Split(';');
            Origen = new Oracle(ConfigurationManager.AppSettings["from"], false, true);
            Destino = new Oracle(ConfigurationManager.AppSettings["to"], GenerateScript, RunScript);

            try
            {
                // *** Esquemas **
                foreach (var schema in Schemas)
                {
                    if (!Origen.ExistsSchema(schema))
                        continue;

                    if (!Destino.ExistsSchema(schema))
                        Destino.CreateSchema(schema);

                    // *** Tablas ***
                    var tablas = Origen.GetTables(schema);

                    foreach (var tabla in tablas)
                    {
                        var oInfo = Origen.GetTableInfo(schema, tabla);

                        if (!Destino.ExistsTabla(schema, tabla))
                            Destino.CreateTabla(oInfo);

                        var dInfo = Destino.GetTableInfo(schema, tabla);

                        Tables.Add(schema, tabla, oInfo, dInfo);

                        // *** Columnas ***
                        var deleted = dInfo.Columns.Select(p => p.Name).Where(d => !oInfo.Columns.Select(o => o.Name).Contains(d));
                        var news = oInfo.Columns.Select(p => p.Name).Where(o => !dInfo.Columns.Select(d => d.Name).Contains(o));
                        var updates = oInfo.Columns.Select(p => p.Name).Where(o => dInfo.Columns.Select(d => d.Name).Contains(o));
                        updates = updates.Where(u => dInfo.Columns.Single(p => p.Name == u).GetHash() != oInfo.Columns.Single(p => p.Name == u).GetHash());
                        Log.Trace($"{schema}.{(tabla + new string(' ', 30)).Substring(0, 30)} 1ra Parte (COLS: I:{news.Count()} U:{updates.Count()} D:{deleted.Count()}) (PK)");

                        foreach (var del in deleted) Destino.DropColumn(schema, tabla, del);
                        foreach (var ins in news) Destino.CreateColumn(schema, tabla, oInfo.Columns.Single(p => p.Name == ins));
                        foreach (var upd in updates) Destino.AlterColumn(schema, tabla, oInfo.Columns.Single(p => p.Name == upd));


                        // *** Comparar PK y FK ***
                        if (oInfo.PrimaryKey == null && dInfo.PrimaryKey == null)   // no tiene ni tuvo
                        {
                        }
                        else if (oInfo.PrimaryKey == null && dInfo.PrimaryKey != null)   // se quitó
                        {
                            Destino.DropConstraint(schema, tabla, dInfo.PrimaryKey.Name);
                        }
                        else if (oInfo.PrimaryKey != null && dInfo.PrimaryKey == null)  // se agregó
                        {
                            Destino.CreateConstraint(schema, tabla, oInfo.PrimaryKey);
                        }
                        else if (oInfo.PrimaryKey.GetHash() != dInfo.PrimaryKey.GetHash()) // se modificó
                        {
                            Destino.DropConstraint(schema, tabla, dInfo.PrimaryKey.Name);
                            Destino.CreateConstraint(schema, tabla, oInfo.PrimaryKey);
                        }
                    }
                }

                // *** Esquemas ** 2da parte
                Log.Trace($"ESQUEMAS 2da Parte");
                foreach (var t in Tables)
                {
                    Log.Trace($"{t.V1}.{(t.V2 + new string(' ', 30)).Substring(0, 30)} 2da Parte (FK)");
                    var schema = t.V1;
                    var tabla = t.V2;
                    var oInfo = t.V3;
                    var dInfo = t.V4;

                    var deleted = dInfo.Constraints.Select(p => p.Name).Where(d => !oInfo.Constraints.Select(o => o.Name).Contains(d));
                    var news = oInfo.Constraints.Select(p => p.Name).Where(o => !dInfo.Constraints.Select(d => d.Name).Contains(o));
                    var updates = oInfo.Constraints.Select(p => p.Name).Where(o => dInfo.Constraints.Select(d => d.Name).Contains(o));
                    updates = updates.Where(u => dInfo.Constraints.Single(p => p.Name == u).GetHash() != oInfo.Constraints.Single(p => p.Name == u).GetHash());

                    deleted = deleted.Concat(updates);
                    news = news.Concat(updates);

                    if (schema == "SIR" && tabla == "AGENCIA")
                    {
                        int i = 0;
                    }
                    foreach (var del in deleted) Destino.DropConstraint(schema, tabla, del);
                    foreach (var ins in news) Destino.CreateConstraint(schema, tabla, oInfo.Constraints.Single(p => p.Name == ins));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            Log.Trace($"Fin de Proceso...");
            Console.ReadLine();
        }
    }
}
