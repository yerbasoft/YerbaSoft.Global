using SIR.Common.DAL.SP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL
{
    public interface IDAO
    {
        /// <summary>
        /// Inicia una nueva transación de base de datos
        /// </summary>
        void BeginTran();

        /// <summary>
        /// Guarda los datos pendientes de la transacción activa
        /// </summary>
        void Commit();

        /// <summary>
        /// Descarta todos los cambios pendientes y cierra la transacción activa
        /// </summary>
        void Rollback();
    }
}
