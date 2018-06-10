using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.Common.DTO
{
    public class SecurityToken
    {
        public Guid IdUser { get; set; }
        public string Token { get; set; }
        public DateTime VencimientoUTC { get; set; }
        
        /// <summary>
        /// Genera un nuevo Token para un usuario y una fecha de vencimiento
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="vencUTL"></param>
        /// <returns></returns>
        public static SecurityToken Generate(Guid idUser, DateTime vencUTL)
        {
            string unitKey = idUser.ToString() + vencUTL.ToString("yyyy-MM-dd HH:mm").PadLeft(20, '0');

            byte[] array = Encoding.ASCII.GetBytes(unitKey).Reverse().ToArray();

            for (var i = 0; i < array.Length; i++)
            {
                int newValue = (array[i] + 20 + i) * i;
                array[i] = (byte)(newValue % 255);
            }

            return new SecurityToken() { IdUser = idUser, Token = Convert.ToBase64String(array), VencimientoUTC = vencUTL };
        }

        /// <summary>
        /// Indica si el Token es válido
        /// </summary>
        /// <returns></returns>
        public Result IsValid(bool allowAnonimo = false)
        {
            if (allowAnonimo && this.IdUser == User.Anonimo.Id)
                return new Result(true);

            if (string.IsNullOrEmpty(this.Token) || this.IdUser == Guid.Empty)
                return new Result("Formato de Token no válido");

            var tk = Convert.FromBase64String(this.Token);
            if (tk.Length != 56)
                return new Result($"Formato de Token no válido. {tk}");


            var tokenExpected = SecurityToken.Generate(this.IdUser, this.VencimientoUTC);
            if (this.Token != tokenExpected.Token)
                return new Result($"Formato de Token no válido. {tk}");

            if (this.VencimientoUTC < DateTime.UtcNow)
                return new Result("Token Vencido");

            return new Result(true);
        }
    }
}
