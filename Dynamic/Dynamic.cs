using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic
{
    public class Dynamic
    {
        private static Dictionary<string, Type> Types { get; set; } = new Dictionary<string, Type>();

        public static object Exec(string mode, string expression, Dictionary<string, object> values)
        {
            return Exec(mode, expression, values, null, null);
        }
        public static object Exec(string mode, string expression, Dictionary<string, object> values, string[] referenceDlls, string[] usings)
        {
            switch(mode.ToUpper())
            {
                case "C#":
                    return ExecCSharp(expression, values, referenceDlls, usings);
                default:
                    return string.Format("- MODO DESCONOCIDO ({0})-", mode);
            }
        }
        
        public static object ExecCSharp(string expression, Dictionary<string, object> parms)
        {
            return ExecCSharp(expression, parms, null, null);
        }
        public static object ExecCSharp(string expression, Dictionary<string, object> parms, string[] referenceDlls, string[] usings)
        {
            parms = parms ?? new Dictionary<string, object>();
            referenceDlls = referenceDlls ?? new string[] { };
            usings = usings ?? new string[] { };

            // Key del Type
            var parmsDefinition = string.Join(", ", parms.Select(p => string.Format("dynamic {0}", p.Key)));
            var key = string.Join(";", usings) + "||" + parmsDefinition + "||" + expression;

            Type type = null;
            if (Types.ContainsKey(key))
            {
                type = Types[key];
            }
            else
            {
                using (Microsoft.CSharp.CSharpCodeProvider foo = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    // Referencias
                    var refs = new System.CodeDom.Compiler.CompilerParameters() { GenerateInMemory = true };
                    refs.ReferencedAssemblies.Add("System.dll");
                    refs.ReferencedAssemblies.Add("System.Core.dll");
                    refs.ReferencedAssemblies.Add("System.Data.dll");
                    refs.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                    foreach (var r in referenceDlls)
                        refs.ReferencedAssemblies.Add(r);

                    // Codigo
                    var code = new StringBuilder();
                    code.AppendLine("using System;");
                    code.AppendLine("using System.Linq;");
                    code.AppendLine("using System.Text;");
                    foreach (var u in usings)
                        code.AppendLine((u.StartsWith("using ") ? u : ("using " + u)) + (u.EndsWith(";") ? "" : ";"));
                    code.AppendLine("");
                    code.AppendLine("public class DynamicClass");
                    code.AppendLine("{");
                    code.AppendLine("    public static object Execute(" + parmsDefinition + ")");
                    code.AppendLine("    {");
                    code.AppendLine("        " + expression);
                    code.AppendLine("    }");
                    code.AppendLine("}");

                    var fullCode = code.ToString();
                    var res = foo.CompileAssemblyFromSource(refs, fullCode);

                    if (res.Errors != null && res.Errors.Count > 0)
                    {
                        throw Exceptions.CompileException.Get(fullCode, "YerbaSoft.Dynamic", parms, res.Errors);
                    }

                    type = res.CompiledAssembly.GetType("DynamicClass");
                    try { Types.Add(key, type); } catch { }
                }
            }

            var parmsValues = parms.Select(p => p.Value).ToArray();
            return type.GetMethod("Execute").Invoke(null, parmsValues);
        }
    }
}
