using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration
{
    public class Cuenta
    {
        [Direct]
        public string Name { get; internal set; }

        [Direct]
        public string Login { get; set; }

        [Direct]
        public string Pass { get; set; }

        [Direct]
        public string Type { get; set; }

        [Direct(UseComplexConvert = true)]
        public bool? AntiFreeze { get; set; }

        [Direct(UseComplexConvert = true)]
        public bool? ShowInfo { get; set; }
    }
}
