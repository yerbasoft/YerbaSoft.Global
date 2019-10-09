using SIR.Common.Batch;
using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.BLL.DTO.File
{
    public class FileHeader : ISplitted
    {
        public const string Index = "01";

        [Split(2, 18)]
        public string Banco { get; set; }

        [Split(20,6, DateTimeFormat = "yyMMdd")]
        public DateTime Fecha { get; set; }


        public Response IsValidRow(string row)
        {
            if (row?.Length < 29)
                return new Response($"La línea no cumple con el length mínimo de 29. row: '{row}'");

            return new Response(true);
        }
    }
}
