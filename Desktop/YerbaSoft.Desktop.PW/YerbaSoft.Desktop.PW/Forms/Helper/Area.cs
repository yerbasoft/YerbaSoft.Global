using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    public class Area
    {
        public event EventHandler<Area> OnEnabledChange;

        public string Name { get; set; }

        public Rectangle Rect { get; set; }

        public bool Clickeable { get; set; }

        private bool _Enabled { get; set; }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; OnEnabledChange?.Invoke(this, this); } }
    }
}
