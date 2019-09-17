using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration.Villa
{
    public class VillaPoint
    {
        [Direct(UseComplexConvert = true)]
        public uint RequestItem { get; set; }

        [Direct]
        public string QuestName { get; set; }

        [Direct]
        public string MoveOnExit { get; set; } // opcional, coordenadas separadas por "X;Z"

        [Direct(UseComplexConvert = true)]
        public float MinYOnExit { get; set; }

        [Direct(UseComplexConvert = true)]
        public int MinFlyForArrive { get; set; }    // altura del juego

        [Direct(UseComplexConvert = true)]
        public uint NPC_dbCode { get; set; }

        [Direct(UseComplexConvert = true)]
        public float NPC_X { get; set; }

        [Direct(UseComplexConvert = true)]
        public float NPC_Z { get; set; }
    }
}
