using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VentasServicios.Modelo;
using VentasServicios.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace VentasServicios.Aplicacion
{
    public class Consulta
    {
        public class ListarVenta : IRequest<List<VentaDto>>
        {
        }
        //recibe librp y regra un autor dto
        public class Manejador : IRequestHandler<ListarVenta, List<VentaDto>>
        {
            private readonly ContextoVenta _context;
            private readonly IMapper _mapper;


            public Manejador(ContextoVenta context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            //recibe una lista de autor
            public async Task<List<VentaDto>> Handle(ListarVenta request, CancellationToken cancellationToken)
            {
                //ir a a base de datos y una consulta
                var ventas = await _context.Ventas.ToListAsync();
                //De autor libro lo pasamos a dto
                var ventaDto = _mapper.Map<List<VentaTienda>, List<VentaDto>>(ventas);
                return ventaDto;
            }
        }
    }
}

