using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using YerbaSoft.DAL.Repositories;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    public class Dados
    {
        public Dados(IEnumerable<Dado> originales)
        {
            this.Originales = new List<Dado>(originales);
        }

        public List<Dado> Originales { get; set; } = new List<Dado>();
        public List<Dado> Temporaries { get; set; } = new List<Dado>();

        /// <summary>
        /// Agita los dados
        /// </summary>
        /// <returns></returns>
        public Dados ShuffleDados()
        {
            foreach (var d in this.Originales)
                d.Shufle();

            foreach (var d in this.Temporaries)
                d.Shufle();

            return this;
        }

        /// <summary>
        /// Devuelve los valores de los dados
        /// </summary>
        /// <param name="cleanTemporary">indica si se deben eliminar los dados temporales</param>
        /// <returns></returns>
        public int?[] GetValues(bool cleanTemporary)
        {
            var values = this.Originales.Select(p => p.Value).Concat(this.Temporaries.Select(p => p.Value)).ToArray();

            if (cleanTemporary)
                this.Temporaries.Clear();

            return values;
        }
    }

    [AutoMapping]
    public class Dado : XmlSimpleClass
    {
        [Direct]
        [ScriptIgnore]
        public string AllowValues { get; set; }

        [NoMap]
        public int? Value { get; set; } = null;

        public Dado() { }
        public Dado(int[] allowValues)
        {
            this.AllowValues = string.Join(";", allowValues);
        }


        /// <summary>
        /// Elije un valor al azar
        /// </summary>
        /// <returns></returns>
        public Dado Shufle()
        {
            this.Value = AllowValues.Split(';').Select(p => System.Convert.ToInt32(p)).GetRandomValue();
            return this;
        }
    }
}
