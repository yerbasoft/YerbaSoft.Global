using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic.Exceptions
{
    public class CompileException : ApplicationException
    {
        private string _StackTrace;
        public override string StackTrace { get { return this._StackTrace; } }

        private CompileExceptionParams _Data;
        public override System.Collections.IDictionary Data { get { return this._Data; } }

        private string _Source;
        public override string Source { get { return _Source; } }

        public CompileException(string message, string stackTrace, string source, Dictionary<string, object> parms, Exception inner) : base(message, inner)
        {
            this._StackTrace = stackTrace;
            this._Source = source;
            this._Data = new CompileExceptionParams(parms);
        }

        internal static CompileException Get(string stackTrace, string source, Dictionary<string, object> parms, CompilerErrorCollection errors)
        {
            CompileException ex = null;
            foreach (var e in errors.OfType<CompilerError>())
            {
                var message = string.Format("[{0}:{1}] ({2}) {3}", e.Line, e.Column, e.ErrorNumber, e.ErrorText);
                var n = new CompileException(message, stackTrace, source, parms, ex);
                ex = n;
            }
            return ex;
        }
    }
}