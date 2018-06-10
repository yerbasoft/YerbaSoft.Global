using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic.CustomFormat
{
    public class CustomFormat
    {
        public delegate string _OnResolveExpression(Dictionary<string, object> values, string fullexpression, string mode, string expression, string valorCalculado);
        public event _OnResolveExpression OnResolveExpression;

        public string Resolve(string format, Dictionary<string, object> values)
        {
            return Resolve(format, values, new YerbaSoft.Dynamic.CustomFormat.CustomFormatDefault());
        }
        public string Resolve(string format, Dictionary<string, object> values, YerbaSoft.Dynamic.CustomFormat.CustomFormatBase config)
        {
            config.OnResolveExpression += CustomFormat_OnResolveExpression;

            return config.Resolve(format, values);
        }

        protected virtual string CustomFormat_OnResolveExpression(Dictionary<string, object> values, string fullexpression, string mode, string expression, string valorCalculado)
        {
            if (OnResolveExpression != null)
                return OnResolveExpression(values, fullexpression, mode, expression, valorCalculado);
            return valorCalculado;
        }
    }
}
