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
    public class AutoAssistConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public enum DataTypes
        {
            None,
            Key,
            Time,
            OrdenInParty
        }

        [Direct] public string AssistPJKey { get; set; }
        [Direct] public string AssistKey { get; set; }
        [Direct] public int AssistTime { get; set; }

        [Direct] public int FollowOrden { get; set; }
        
        [Direct] public string Atk1 { get; set; }
        [Direct] public string Atk2 { get; set; }
        [Direct] public string Atk3 { get; set; }
        [Direct] public string Atk4 { get; set; }
        [Direct] public string Atk5 { get; set; }
        [Direct] public string Atk6 { get; set; }
        [Direct] public int AtkTime1 { get; set; }
        [Direct] public int AtkTime2 { get; set; }
        [Direct] public int AtkTime3 { get; set; }
        [Direct] public int AtkTime4 { get; set; }
        [Direct] public int AtkTime5 { get; set; }
        [Direct] public int AtkTime6 { get; set; }

        public static DataTypes GetDataType(string field)
        {
            switch (field)
            {
                case "AssistKey":
                case "AssistPJKey":
                case "Atk1":
                case "Atk2":
                case "Atk3":
                case "Atk4":
                case "Atk5":
                case "Atk6":
                    return DataTypes.Key;
                case "AssistTime":
                case "AtkTime1":
                case "AtkTime2":
                case "AtkTime3":
                case "AtkTime4":
                case "AtkTime5":
                case "AtkTime6":
                    return DataTypes.Time;
                case "FollowOrden":
                    return DataTypes.OrdenInParty;
                default:
                    return DataTypes.None;
            }
        }

        public static string GetTitle(string field)
        {
            switch (field)
            {
                case "AssistPJKey":
                    return "PJ Select Key";
                case "AssistKey":
                    return "Assist Skill";
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
                case "AssistTime":
                case "AtkTime1":
                case "AtkTime2":
                case "AtkTime3":
                case "AtkTime4":
                case "AtkTime5":
                case "AtkTime6":
                    return "Time";
                case "FollowOrden":
                    return "Orden Party";
                default:
                    return "----";
            }
        }

        public object GetValue(string prop)
        {
            return typeof(AutoAssistConfig).GetProperty(prop).GetValue(this);
        }

        public void SetValue(string prop, object value)
        {
            typeof(AutoAssistConfig).GetProperty(prop).SetValue(this, value);
        }

        internal Two<Keys, int> GetAtk(int i)
        {
            var k = (string)typeof(AutoAssistConfig).GetProperty($"Atk{i}").GetValue(this);
            var t = (int?)typeof(AutoAssistConfig).GetProperty($"AtkTime{i}").GetValue(this);

            if (Enum.TryParse<Keys>(k, out Keys key) && (t ?? 0) > 0)
                return new Two<Keys, int>(key, t.Value);
            else
                return null;
        }
    }
}
