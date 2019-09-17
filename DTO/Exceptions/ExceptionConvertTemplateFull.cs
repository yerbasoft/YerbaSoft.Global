using System.Text;

namespace YerbaSoft.DTO.Exceptions
{
    public class ExceptionConvertTemplateFull : ExceptionConvertTemplateBase
    {
        protected override string Template
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("-------------------------- EXCEPTION --------------------------");
                //sb.Append("{C#::System.String.IsNullOrEmpty(CurrentUser) ? null : \"Current User: \" + CurrentUser + System.Environment.NewLine}");
                sb.AppendLine("Current Date: {C#::System.DateTime.Now.ToString(\"dd/MM/yyyy HH:mm:ss\")}");
                sb.AppendLine("Exception: {C#::ex.GetType().FullName}");
                sb.AppendLine("Message: {C#::ex.Message}");
                sb.AppendLine("Source: {C#::ex.Source}");
                sb.AppendLine("Trace: {C#::ex.StackTrace}");
                sb.AppendLine("{INNEREXCEPTION}");
                return sb.ToString();
            }
        }

        protected override string TemplateInner
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("------------------- INNER EXCEPTION -------------------");
                sb.AppendLine("Exception: {C#::ex.GetType().FullName}");
                sb.AppendLine("Message: {C#::ex.Message}");
                sb.AppendLine("Source: {C#::ex.Source}");
                sb.AppendLine("Trace: {C#::ex.StackTrace}");
                sb.AppendLine("{INNEREXCEPTION}");
                return sb.ToString();
            }
        }

        protected override bool Use2SpaceInTabsForInnerException
        {
            get { return true; }
        }

        protected override int TabsForInnerException
        {
            get { return 2; }
        }
    }
}
