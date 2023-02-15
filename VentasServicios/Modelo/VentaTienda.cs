using System.Collections.Generic;
using System;

namespace VentasServicios.Modelo
{
    public class VentaTienda
    {
        public int VentaTiendaId { get; set; }
        public int Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

        public string VentaTiendaGuid { get; set; }
    }
}
