using Microsoft.EntityFrameworkCore;
using VentasServicios.Modelo;

namespace VentasServicios.Persistencia
{
    public class ContextoVenta : DbContext
    {
        public ContextoVenta(DbContextOptions<ContextoVenta> options) : base(options)
        {

        }

        public DbSet<VentaTienda> Ventas { get; set; }
    }
}