using SIR.BcoCiudad.Common.Entities;
using SIR.Common.DAL;

namespace SIR.BcoCiudad.Common.Interfaces
{
    public interface IDAO : SIR.Common.DAL.IDAO, SIR.Common.DAL.Configuration.IDAOConfig
    {
        IRepository<Encabezado> Encabezado { get; }
        IRepository<Dependencia> Dependencia { get; }
        IRepository<Detalle> Detalle { get; }
    }
}
