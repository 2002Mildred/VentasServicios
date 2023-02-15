using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentasServicios.Aplicacion;

namespace VentasServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Que herede de controller base
    public class VentaController : ControllerBase
    {

        private readonly IMediator _medietor;

        public VentaController(IMediator medietor)
        {
            _medietor = medietor;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _medietor.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<VentaDto>>> GetAutores()
        {
            return await _medietor.Send(new Consulta.ListarVenta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDto>> GetAutorLibro(string id)
        {
            return await _medietor.Send(new ConsultaFiltro.VentaUnico { VentaGuid = id });
        }


    }
}
