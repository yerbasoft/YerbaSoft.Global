using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO.Exceptions
{
    public class ExceptionConvertTemplateOnlyMessage : ExceptionConvertTemplateBase
    {
        protected override string Template { get { return "{C#::ex.Message}"; } }
        protected override string TemplateInner { get { return null; } }
        protected override int TabsForInnerException { get { return 0; } }
        protected override bool Use2SpaceInTabsForInnerException { get { return false; } }
    }
}