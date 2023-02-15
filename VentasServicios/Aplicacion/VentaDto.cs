using System;

namespace VentasServicios.Aplicacion
{
    public class VentaDto
    {
        public int VentaTiendaId { get; set; }
        public int Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public string VentaTiendaGuid { get; set; }
    }
}
