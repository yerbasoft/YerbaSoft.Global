namespace YerbaSoft.DTO.Exceptions
{
    public class ExceptionConvertTemplateLight : ExceptionConvertTemplateBase
    {
        protected override string Template
        {
            get
            {
                return string.Format("[{0}]{1}({2})",
                                        "{C#::System.DateTime.Now.ToString(\"yyyyMMddHH:mm:ss\")}",
                                        "{C#::ex.GetType().FullName}",
                                        "{C#::ex.Message}"
                                    ) + "{INNEREXCEPTION}";
            }
        }

        protected override string TemplateInner
        {
            get
            {
                return string.Format(System.Environment.NewLine + "{0}({1})",
                                        "{C#::ex.GetType().FullName}",
                                        "{C#::ex.Message}"
                                    ) + "{INNEREXCEPTION}";
            }
        }

        protected override int TabsForInnerException { get { return 1; } }
        protected override bool Use2SpaceInTabsForInnerException { get { return true; } }
    }
}
