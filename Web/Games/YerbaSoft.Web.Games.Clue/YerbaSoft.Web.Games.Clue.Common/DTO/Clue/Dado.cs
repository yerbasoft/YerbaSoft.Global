using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DAL.Repositories;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Dado: XmlSimpleClass
    {
        [Direct]
        public string AllowValues { get; set; }

        [NoMap]
        public int? Value { get; set; } = null;

        /// <summary>
        /// Elije un valor al azar
        /// </summary>
        /// <returns></returns>
        public Dado Shufle()
        {
            this.Value = AllowValues.Select(p => System.Convert.ToInt32(p)).GetRandomValue();
            return this;
        }
    }
}
