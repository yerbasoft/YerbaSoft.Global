using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL
{
    public static class IExtensions
    {
        #region Exceptions

        /// <summary>
        /// Indica que el campo será de tipo bool y se almacenará como Y/N
        /// </summary>
        public static PropertyBuilder<bool> YesNoType(this PropertyBuilder<bool> prop)
        {
            return prop.HasConversion(EF.Converter.YesNoType);
        }

        /// <summary>
        /// Indica que el campo será de tipo bool? y se almacenará como null/Y/N
        /// </summary>
        public static PropertyBuilder<bool?> YesNoType(this PropertyBuilder<bool?> prop)
        {
            return prop.HasConversion(EF.Converter.YesNoNullType);
        }

        #endregion
    }
}
