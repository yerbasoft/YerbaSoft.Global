using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.EF
{
    internal static class Converter
    {
        public static ValueConverter YesNoType => new ValueConverter<bool, string>(
            v => v ? "Y" : "N",
            v => v == "Y"
        );

        public static ValueConverter YesNoNullType => new ValueConverter<bool?, string>(
            v => (v == null) ? null : (v == true ? "Y" : "N"),
            v => (v == null ? (bool?)null : (v == "Y" ? true : false))
        );
    }
}
