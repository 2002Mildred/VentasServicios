using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using VentasServicios.Modelo;
using VentasServicios.Persistencia;

namespace VentasServicios.Aplicacion
{
    public class Nuevo
    {
        //parametros del controlador
        //Son los que se van insertar en la base de datos
        public class Ejecuta : IRequest
        {
            public int Total { get; set; }
            public DateTime? Fecha { get; set; }
            public int Cantidad { get; set; }
        }
        //validacion abstrata
        //clase que valida la clase ejecuta a traves de apifluent validator
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Cantidad).NotEmpty(); //No acepta valores nulos
                RuleFor(p => p.Total).NotEmpty();
                RuleFor(p => p.Fecha).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            //mapeas datos
            public readonly ContextoVenta _context;
            //CDI inyectando contextoAutor
            public Manejador(ContextoVenta context)
            {
                _context = context;
            }
            //Medodo Hadler te pide lo que vas a manejar
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //se crea la  instancia del autor libro ligado a contexto
                var autorLibro = new VentaTienda
                {
                    Total = request.Total,
                    Fecha = request.Fecha,
                    Cantidad = request.Cantidad,
                    VentaTiendaGuid = Convert.ToString(Guid.NewGuid())
                };
                //agregamos el objeto del tipo autor libro
                _context.Ventas.Add(autorLibro);
                //insertamos el valor de insercion por LINQ
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puedo insertar el autor del libro");
            }
        }
    }
}

