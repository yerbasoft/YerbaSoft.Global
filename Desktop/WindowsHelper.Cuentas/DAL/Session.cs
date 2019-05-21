using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Cuentas.DAL
{
    internal class Session
    {
        private static YerbaSoft.DAL.IRepository<DTO.Concepto> _Conceptos;
        public static YerbaSoft.DAL.IRepository<DTO.Concepto> Conceptos => 
            _Conceptos = _Conceptos ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Concepto>(System.IO.Path.Combine(CuentasApp.DBPath, "WindowsHelper.Cuentas.Conceptos.xml"));

        private static YerbaSoft.DAL.IRepository<DTO.Movimiento> _Movimientos;
        public static YerbaSoft.DAL.IRepository<DTO.Movimiento> Movimientos =>
            _Movimientos = _Movimientos ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Movimiento>(System.IO.Path.Combine(CuentasApp.DBPath, "WindowsHelper.Cuentas.Movimientos.xml"));
        
        private static YerbaSoft.DAL.IRepository<DTO.Ahorro> _Ahorros;
        public static YerbaSoft.DAL.IRepository<DTO.Ahorro> Ahorros =>
            _Ahorros = _Ahorros ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Ahorro>(System.IO.Path.Combine(CuentasApp.DBPath, "WindowsHelper.Cuentas.Ahorros.xml"));
    }
}
