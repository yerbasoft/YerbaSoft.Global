namespace YerbaSoft.DTO.Mapping.Config
{
    public class ManualAutoMappingCongif : AutoMappingConfig
    {
        public bool SetUseExtraMapping { get; set; }
        internal override bool UseExtraMapping { get { return SetUseExtraMapping; } }

        public bool SetThrowErrorOnDirect { get; set; }
        internal override bool ThrowErrorOnDirect { get { return SetThrowErrorOnDirect; } }

        public bool SetMapSubClass { get; set; }
        internal override bool MapSubClass { get { return SetMapSubClass; } }

        public bool SetCaseSensitive { get; set; }
        internal override bool CaseSensitive { get { return SetCaseSensitive; } }

        public ManualAutoMappingCongif()
        {
            Mapping.Map.CopyTo(new DefaultAutomappingConfig(), this);   // arranco con las propiedades default?
        }
        public ManualAutoMappingCongif(bool useExtraMapping, bool throwErrorOnDirect, bool mapSubClass, bool caseSensitive)
        {
            this.SetThrowErrorOnDirect = throwErrorOnDirect;
            this.SetUseExtraMapping = useExtraMapping;
            this.SetMapSubClass = mapSubClass;
            this.SetCaseSensitive = caseSensitive;
        }
    }
}
