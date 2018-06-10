using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO
{
    [AutoMapping]
    public class Usuario
    {
        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public string Nombre { get; set; }
        [Direct]
        public string Login { get; set; }
        private char _Sexo;
        [Direct(true)]
        public char Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                if (!YerbaSoft.DTO.Math.In(value, 'M', 'F', default(char)))
                    throw new System.InvalidCastException("El sexo de una persona por el momento debe ser Masculino o Femenino");
                _Sexo = value;
            }
        }
        [Direct]
        public string Logo { get; set; }

        public Usuario()
        {
            //Sexo = 'M'; //Masculino por default
        }
    }
}
