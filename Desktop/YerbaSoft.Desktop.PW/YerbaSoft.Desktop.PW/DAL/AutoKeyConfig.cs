using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class AutoKeyConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public int TimeF1 { get; set; }
        [Direct] public int TimeF2 { get; set; }
        [Direct] public int TimeF3 { get; set; }
        [Direct] public int TimeF4 { get; set; }
        [Direct] public int TimeF5 { get; set; }
        [Direct] public int TimeF6 { get; set; }
        [Direct] public int TimeF7 { get; set; }
        [Direct] public int TimeF8 { get; set; }
        [Direct] public int TimeTab { get; set; }
        [Direct] public int TimeD1 { get; set; }
        [Direct] public int TimeD2 { get; set; }
        [Direct] public int TimeD3 { get; set; }
        [Direct] public int TimeD4 { get; set; }
        [Direct] public int TimeD5 { get; set; }
        [Direct] public int TimeD6 { get; set; }
        [Direct] public int TimeD7 { get; set; }
        [Direct] public int TimeD8 { get; set; }
        [Direct] public int TimeD9 { get; set; }

        public Dictionary<Keys, int> GetDictionary()
        {
            return new Dictionary<Keys, int>()
            {
                { Keys.F1, this.TimeF1 },{ Keys.F2, this.TimeF2 },{ Keys.F3, this.TimeF3 },{ Keys.F4, this.TimeF4 },{ Keys.F5, this.TimeF5 },{ Keys.F6, this.TimeF6 },{ Keys.F7, this.TimeF7 },{ Keys.F8, this.TimeF8 },{ Keys.Tab, this.TimeTab },
                { Keys.D1, this.TimeD1 },{ Keys.D2, this.TimeD2 },{ Keys.D3, this.TimeD3 },{ Keys.D4, this.TimeD4 },{ Keys.D5, this.TimeD5 },{ Keys.D6, this.TimeD6 },{ Keys.D7, this.TimeD7 },{ Keys.D8, this.TimeD8 },{ Keys.D9, this.TimeD9 }
            };
        }

        public void SetValue(Keys key, int value)
        {
            var p = typeof(AutoKeyConfig).GetProperty($"Time{key.ToString()}");
            p.SetValue(this, value);
        }

        public int GetValue(Keys key)
        {
            var p = typeof(AutoKeyConfig).GetProperty($"Time{key.ToString()}");
            return (int)p.GetValue(this);
        }
        
        public Dictionary<Keys, int> GetConfiguredKeys()
        {
            var result = new Dictionary<Keys, int>();
            if (this.TimeF1 > 0) result.Add(Keys.F1, this.TimeF1);
            if (this.TimeF2 > 0) result.Add(Keys.F2, this.TimeF2);
            if (this.TimeF3 > 0) result.Add(Keys.F3, this.TimeF3);
            if (this.TimeF4 > 0) result.Add(Keys.F4, this.TimeF4);
            if (this.TimeF5 > 0) result.Add(Keys.F5, this.TimeF5);
            if (this.TimeF6 > 0) result.Add(Keys.F6, this.TimeF6);
            if (this.TimeF7 > 0) result.Add(Keys.F7, this.TimeF7);
            if (this.TimeF8 > 0) result.Add(Keys.F8, this.TimeF8);
            if (this.TimeTab > 0) result.Add(Keys.Tab, this.TimeTab);
            if (this.TimeD1 > 0) result.Add(Keys.D1, this.TimeD1);
            if (this.TimeD2 > 0) result.Add(Keys.D2, this.TimeD2);
            if (this.TimeD3 > 0) result.Add(Keys.D3, this.TimeD3);
            if (this.TimeD4 > 0) result.Add(Keys.D4, this.TimeD4);
            if (this.TimeD5 > 0) result.Add(Keys.D5, this.TimeD5);
            if (this.TimeD6 > 0) result.Add(Keys.D6, this.TimeD6);
            if (this.TimeD7 > 0) result.Add(Keys.D7, this.TimeD7);
            if (this.TimeD8 > 0) result.Add(Keys.D8, this.TimeD8);
            if (this.TimeD9 > 0) result.Add(Keys.D9, this.TimeD9);

            return result;
        }
    }
}
