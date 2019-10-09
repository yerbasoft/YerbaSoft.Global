using SIR.BcoCiudad.Common.Entities;
using SIR.Common.DAL;
using SIR.Common.DAL.EF;
using System.Reflection;

namespace SIR.BcoCiudad.DAL
{
    public class DAO : EFDAO, Common.Interfaces.IDAO
    {
        public DAO(string connectionString) : base(connectionString, "IBC", Assembly.GetExecutingAssembly()) { }

        public IRepository<Encabezado> _Encabezado;
        public IRepository<Dependencia> _Dependencia;
        public IRepository<Detalle> _Detalle;

        public IRepository<Encabezado> Encabezado => _Encabezado = _Encabezado ?? this.GetRepository<Encabezado>();
        public IRepository<Dependencia> Dependencia => _Dependencia = _Dependencia ?? this.GetRepository<Dependencia>();
        public IRepository<Detalle> Detalle => _Detalle = _Detalle ?? this.GetRepository<Detalle>();


    }
}
