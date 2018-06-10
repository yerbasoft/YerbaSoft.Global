using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.TEST
{
    public class ClaseLocal
    {
        public string A { get; set; }
        public string B { get; set; }
    }

    class Program
    {
        public class PepeType
        {
            public string res { get; set; }

        }

        static void Main(string[] args)
        {
            /*
            var rulesResults = new string[] { "GG", "IZI", "PIZI" };
            var T = new PepeType() { res = "__0__1__2__" };
            
            rulesResults.Select((p, i) =>
                T.res = T.res.Replace($"{i}",rulesResults[i].ToString().ToLower())
            ).Last();

            // T.res tiene el valor modificado
            
            ClaseLocal pp = Proxy();
            */
        }
        
        internal static ClaseLocal Proxy()
        {
            var ori = new ClaseLocal() { A = "A", B = "B" };

            var t = GetNewType(ori);

            var obj = t.GetConstructor(new Type[] { }).Invoke(null);

            ((ClaseLocal)obj).A = ori.A;
            ((ClaseLocal)obj).B = ori.B;
            ((dynamic)obj).Id = "esto es un ID oculto??";
            
            return (ClaseLocal)obj;
        }

        internal static Type GetNewType<T>(T ori)
        {

            
            using (Microsoft.CSharp.CSharpCodeProvider foo = new Microsoft.CSharp.CSharpCodeProvider())
            {
                // Referencias
                var refs = new System.CodeDom.Compiler.CompilerParameters() { GenerateInMemory = true };
                refs.ReferencedAssemblies.Add("System.dll");
                refs.ReferencedAssemblies.Add("System.Core.dll");
                refs.ReferencedAssemblies.Add("System.Data.dll");
                refs.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                refs.ReferencedAssemblies.Add(typeof(T).Assembly.Location);

                // Codigo
                var code = new StringBuilder();
                code.AppendLine("using System;");
                code.AppendLine("using System.Linq;");
                code.AppendLine("using System.Text;");
                code.AppendLine("");
                code.AppendLine("namespace YerbaSoft.Dynamic");
                code.AppendLine("{");
                code.AppendLine($"    public class ProxyClass : {typeof(T).FullName}");
                code.AppendLine("    {");
                code.AppendLine("        public string Id { get; set; }");
                code.AppendLine("    }");
                code.AppendLine("}");

                var fullCode = code.ToString();
                var res = foo.CompileAssemblyFromSource(refs, fullCode);

                if (res.Errors != null && res.Errors.Count > 0)
                {
                    throw new NotImplementedException();
                }

                return res.CompiledAssembly.GetType("YerbaSoft.Dynamic.ProxyClass");
            }
        }
    }

}