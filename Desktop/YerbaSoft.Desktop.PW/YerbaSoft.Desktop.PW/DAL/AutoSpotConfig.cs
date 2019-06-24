using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class AutoSpotConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public enum DataTypes
        {
            None,
            Key,
            Time,
            TimeMin
        }

        public bool HasPick => !string.IsNullOrEmpty(this.PickKey);
        [Direct] public string PickKey { get; set; }
        [Direct] public int? PickTime { get; set; }

        [Direct] public string AssistKey { get; set; }

        public bool HasBuff => !string.IsNullOrEmpty(this.BuffKey);
        [Direct] public string BuffKey { get; set; }
        [Direct] public int? BuffExpireTime { get; set; }
        [Direct] public int? BuffCastTime { get; set; }

        [Direct] public string Atk1 { get; set; }
        [Direct] public string Atk2 { get; set; }
        [Direct] public string Atk3 { get; set; }
        [Direct] public string Atk4 { get; set; }
        [Direct] public string Atk5 { get; set; }
        [Direct] public string Atk6 { get; set; }
        [Direct] public int? AtkTime1 { get; set; }
        [Direct] public int? AtkTime2 { get; set; }
        [Direct] public int? AtkTime3 { get; set; }
        [Direct] public int? AtkTime4 { get; set; }
        [Direct] public int? AtkTime5 { get; set; }
        [Direct] public int? AtkTime6 { get; set; }

        public static DataTypes GetDataType(string field)
        {
            switch(field)
            {
                case "PickKey":
                case "AssistKey":
                case "BuffKey":
                case "Atk1":
                case "Atk2":
                case "Atk3":
                case "Atk4":
                case "Atk5":
                case "Atk6":
                    return DataTypes.Key;
                case "PickTime":
                case "BuffCastTime":
                case "AtkTime1":
                case "AtkTime2":
                case "AtkTime3":
                case "AtkTime4":
                case "AtkTime5":
                case "AtkTime6":
                    return DataTypes.Time;
                case "BuffExpireTime":
                    return DataTypes.TimeMin;
                default:
                    return DataTypes.None;
            }
        }

        public static string GetTitle(string field)
        {
            switch (field)
            {
                case "PickKey": 
                case "BuffKey":
                    return "Key";
                case "AssistKey":
                    return "Assist";
                case "Atk1":
                    return "Key1";
                case "Atk2":
                    return "Key2";
                case "Atk3":
                    return "Key3";
                case "Atk4":
                    return "Key4";
                case "Atk5":
                    return "Key5";
                case "Atk6":
                    return "Key6";
                case "PickTime":
                case "AtkTime1":
                case "AtkTime2":
                case "AtkTime3":
                case "AtkTime4":
                case "AtkTime5":
                case "AtkTime6":
                    return "Time";
                case "BuffCastTime":
                    return "Cast Time";
                case "BuffExpireTime":
                    return "Expire Time";
                default:
                    return "----";
            }
        }

        public object GetValue(string prop)
        {
            return typeof(AutoSpotConfig).GetProperty(prop).GetValue(this);
        }

        public void SetValue(string prop, object value)
        {
            typeof(AutoSpotConfig).GetProperty(prop).SetValue(this, value);
        }

        internal Two<Keys, int> GetAtk(int i)
        {
            var k = (string)typeof(AutoSpotConfig).GetProperty($"Atk{i}").GetValue(this);
            var t = (int?)typeof(AutoSpotConfig).GetProperty($"AtkTime{i}").GetValue(this);

            if (Enum.TryParse<Keys>(k, out Keys key) && (t ?? 0) > 0)
                return new Two<Keys, int>(key, t.Value);
            else
                return null;
        }
    }
}
