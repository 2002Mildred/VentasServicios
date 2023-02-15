namespace VentasServicios.Modelo
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public int Sueldo { get; set; }
        public string EmpleadoGuid { get; set; }
        public int VentaId { get; set; }
        public string Venta { get; set; }
    }
}
