using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Common.Interfaces
{
    public interface IBcoCiudadService
    {
        void ProcesarArchivos(bool reprocesar);
        void ExportarBUI();
    }
}
