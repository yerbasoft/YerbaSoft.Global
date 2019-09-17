using System.Collections.Generic;
using System.Windows.Forms;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class AutoKeyConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
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

        private List<KeyValueConfig> _Keys;
        /// <summary>
        /// Lista de Keys-Tiempos
        /// </summary>
        [SubList] public List<KeyValueConfig> Keys { get { return _Keys = _Keys ?? new List<KeyValueConfig>(); } set { _Keys = value; } }
    }

    public class KeyValueConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public string Key { get; set; }
        [Direct]
        public int Time { get; set; }

        public override bool Equals(object obj)
        {
            return this.Key == ((KeyValueConfig)obj).Key;
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
