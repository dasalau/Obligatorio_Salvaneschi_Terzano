using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EquiposTrabajoController : ControllerBase
    {
        private ICUGetEquiposPagosUnicosByMonto<EquipoTrabajoDtoListado> _cUGetEquiposPagosUnicosByMonto;
        private ICUGetAll<EquipoTrabajoDtoListado> _cUGetAll;

        public EquiposTrabajoController(ICUGetEquiposPagosUnicosByMonto<EquipoTrabajoDtoListado> cUGetEquiposPagosUnicosByMonto,
                                        ICUGetAll<EquipoTrabajoDtoListado> cUGetAll)
        {
            _cUGetEquiposPagosUnicosByMonto = cUGetEquiposPagosUnicosByMonto;
            _cUGetAll = cUGetAll;
        }


        // GET: api/<EquiposTrabajoController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipoTrabajoDtoListado>> GetAll()
        {

            return Ok(_cUGetAll.Execute());
        }

        [HttpGet]
        [Route("GetEquiposPagosUnicosByMonto/{monto}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<IEnumerable<EquipoTrabajoDtoListado>> GetEquiposPagosUnicosByMonto(double monto)
        {
            try
            {
                if (monto < 0)
                {
                    return BadRequest("El monto no puede ser negativo.");
                }

                var equipos = _cUGetEquiposPagosUnicosByMonto.Execute(monto);

                if (equipos == null || !equipos.Any())
                {
                    return StatusCode(204, "No se encontraron equipos con pagos únicos mayores al monto especificado.");
                }

                return Ok(equipos);
            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
    }
}
