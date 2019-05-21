using System;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.Memory.Configuration
{
    internal class CustomAction : Base
    {
        internal override string TypeName => "CustomMenu";

        [YerbaSoft.DTO.Mapping.Direct]
        public string Service { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Action { get; set; }
        
        internal override void Run()
        {
            var tService = Type.GetType(this.Service);
            if (tService == null)
            {
                Global.Log($"Memory :: CustomAction :: El servicio {this.Service} no existe", LogLevel.Error);
                return;
            }

            var tAction = tService.GetMethod(this.Action);
            if (tService == null)
            {
                Global.Log($"Memory :: CustomAction :: El Método {this.Action} no existe en el servicio {this.Service}", LogLevel.Error);
                return;
            }

            var cService = tService.GetConstructor(new Type[] { });
            if(cService == null)
            {
                Global.Log($"Memory :: CustomAction :: El servicio {this.Service} no posee un constructor sin parámetros", LogLevel.Error);
                return;
            }

            var service = cService.Invoke(new object[] { });

            Global.Log($"Memory :: CustomAction :: Executing :: new {this.Service}().{this.Action}()", LogLevel.Debug);
            tAction.Invoke(service, new object[] { });
        }
    }
}
