namespace YerbaSoft.DTO.Mapping.Config
{
    public class DefaultAutomappingConfig : AutoMappingConfig
    {
        internal override bool UseExtraMapping { get { return true; } }
        internal override bool ThrowErrorOnDirect { get { return false; } }
        internal override bool MapSubClass { get { return true; } }
        internal override bool CaseSensitive { get { return true; } }
    }
}
