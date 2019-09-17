using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class ShowInfoConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        /// <summary>
        /// Dejar a la vista
        /// </summary>
        [Direct]
        public bool WinPinned { get; set; }

        /// <summary>
        /// Indica si se muestra la ventana pegada a la principal.
        /// 0:derecha; 1:Izquierda, 2:abajo, 3:arriba, 5:libre
        /// </summary>
        [Direct]
        public bool WinShowAttachParent { get; set; }

        /// <summary>
        /// Coordenada X de la ventana cuando está "libre"
        /// </summary>
        [Direct]
        public int ScreenX { get; set; }

        /// <summary>
        /// Coordenada Y de la ventana cuando está "libre"
        /// </summary>
        [Direct]
        public int ScreenY { get; set; }
    }
}
