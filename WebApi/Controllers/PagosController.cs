using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagosController : ControllerBase
    {
        private ICUGetById<PagosDtoListado> _cUGetById;
        private ICUGetPagosByUsuarioId<PagosDtoListado> _cUGetPagosByUsuarioId;
        private ICUAddPagoUnico<PagoUnicoDtoAlta> _cuAddPagoUnico;
        private ICUAddPagoRecurrente<PagoRecurrenteDtoAlta> _cuAddPagoRecurrente;
        private ICUGetById<TiposDeGastoDtoListado> _cUGetTipoGastoById;
        private ICUGetById<MetodosDePagoDtoListado> _cUGetMetodoPagoById;
        private ICUGetPagosByTipoGastoId<PagosByTipoGastoDtoReporte> _cUGetPagosByTipoGastoId;


        public PagosController(ICUGetById<PagosDtoListado> cUGetById,
                               ICUGetPagosByUsuarioId<PagosDtoListado> cUGetPagosByUsuarioId,
                               ICUAddPagoUnico<PagoUnicoDtoAlta> cUAddPagoUnico,
                               ICUAddPagoRecurrente<PagoRecurrenteDtoAlta> cUAddPagoRecurrente,
                               ICUGetById<TiposDeGastoDtoListado> cUGetByIdTipoPago,
                               ICUGetById<MetodosDePagoDtoListado> cUGetByIdMetodoPago,
                               ICUGetPagosByTipoGastoId<PagosByTipoGastoDtoReporte> cUGetPagosByTipoGastoId)

        {
            _cUGetById = cUGetById;
            _cUGetPagosByUsuarioId = cUGetPagosByUsuarioId;
            _cuAddPagoUnico = cUAddPagoUnico;
            _cuAddPagoRecurrente = cUAddPagoRecurrente;
            _cUGetTipoGastoById = cUGetByIdTipoPago;
            _cUGetMetodoPagoById = cUGetByIdMetodoPago;
            _cUGetPagosByTipoGastoId = cUGetPagosByTipoGastoId;
        }



        // GET api/<PagosController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetPagoById(int id)
        {

            if (id <= 0)
            {
                return StatusCode(400, "El id debe ser mayor a 0");
            }

            try
            {
                var pago = _cUGetById.Execute(id);

                return StatusCode(200, pago);
            }
            catch (PagosExcepcion ex)
            {
                return StatusCode(404, "No se encontro el pago con id: " + id);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }

        // GET api/<PagosController>/usuario/5

        [HttpGet("byUsuario/{usuarioId}")]
        [Authorize(Roles = "Gerente,Empleado")]
        public IActionResult GetPagosByUsuarioId(int usuarioId)
        {
            //if (HttpContext.Session.GetString("rol") == null ||
            //    HttpContext.Session.GetString("rol") == "Administrador")
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");

            //}

            if (usuarioId <= 0)
            {
                return StatusCode(400, "El id del usuario debe ser mayor a 0");
            }
            try
            {
                var pagos = _cUGetPagosByUsuarioId.Execute(usuarioId);

                if (pagos == null || !pagos.Any())
                {
                    return StatusCode(204, "El usuario no tiene pagos registrados");
                }
                return StatusCode(200, pagos);
            }
            catch (UsuarioExcepcion ex)
            {
                return StatusCode(404, "No se encontro el usuario con id: " + usuarioId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }

        // POST api/<PagosController>/pagoUnico
        [HttpPost("pagoUnico")]
        public IActionResult PostPagoUnico([FromBody] PagoUnicoDtoAlta pagoUnicoDtoAlta)
        {
            //Validaciones del id de tipo de gasto y metodo de pago

            int tipoGastoId = pagoUnicoDtoAlta.TipoGastoId;
            int metodoPagoId = pagoUnicoDtoAlta.MetodoPagoId;

            try
            {
                _cUGetTipoGastoById.Execute(tipoGastoId);
            }
            catch (TipoGastoExcepcion ex)
            {
                return StatusCode(400, "El tipo de gasto con id: " + tipoGastoId + " no existe");
            }


            try
            {
                _cUGetMetodoPagoById.Execute(metodoPagoId);
            }
            catch (MetodoPagoExcepcion ex)
            {
                return StatusCode(400, "El metodo de pago con id: " + metodoPagoId + " no existe");
            }

            //Valido que haya un usuario logueado

            //if (HttpContext.Session.GetString("rol") == null)
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}

            //Valido que el usuarioId del pago unico sea el mismo que el del usuario logueado

            //if (pagoUnicoDtoAlta.UsuarioId != HttpContext.Session.GetInt32("idUsuarioLogueado"))
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}


            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (pagoUnicoDtoAlta.UsuarioId != int.Parse(userId))
            {
                return StatusCode(403, "No tiene permisos para realizar esta acción");
            }

            //Valido la fecha del pago 

            var fechaPago = pagoUnicoDtoAlta.FechaPago.ToString();


            if (!DateTime.TryParse(fechaPago, out DateTime fecha))
            {
                return StatusCode(400, "Formato de fecha invalido");
            }


            //Registro el pago unico
            try
            {
                _cuAddPagoUnico.Execute(pagoUnicoDtoAlta);
                return StatusCode(201, "Pago unico registrado con exito");
            }

            catch (DescripcionExcepcion ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (PagosExcepcion ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado: " + ex.Message);
            }


        }


        // POST api/<PagosController>/pagoRecurrente
        [HttpPost("pagoRecurrente")]
        public IActionResult PostPagoRecurrente([FromBody] PagoRecurrenteDtoAlta pagoRecurrenteDtoAlta)
        {
            //Validaciones del id de tipo de gasto y metodo de pago
            int tipoGastoId = pagoRecurrenteDtoAlta.TipoGastoId;
            int metodoPagoId = pagoRecurrenteDtoAlta.MetodoPagoId;
            try
            {
                _cUGetTipoGastoById.Execute(tipoGastoId);
            }
            catch (TipoGastoExcepcion ex)
            {
                return StatusCode(400, "El tipo de gasto con id: " + tipoGastoId + " no existe");
            }

            try
            {
                _cUGetMetodoPagoById.Execute(metodoPagoId);
            }
            catch (MetodoPagoExcepcion ex)
            {
                return StatusCode(400, "El metodo de pago con id: " + metodoPagoId + " no existe");
            }

            //Valido que haya un usuario logueado   


            //if (HttpContext.Session.GetString("rol") == null)
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}

            //Valido que el usuarioId del pago unico sea el mismo que el del usuario logueado

            //if (pagoRecurrenteDtoAlta.UsuarioId != HttpContext.Session.GetInt32("idUsuarioLogueado"))
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (pagoRecurrenteDtoAlta.UsuarioId != int.Parse(userId))
            {
                return StatusCode(403, "No tiene permisos para realizar esta acción");
            }


            //Registro el pago recurrente
            try
            {
                _cuAddPagoRecurrente.Execute(pagoRecurrenteDtoAlta);
                return StatusCode(201, "Pago recurrente registrado con exito");
            }

            catch (DescripcionExcepcion ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (PagosExcepcion ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado: " + ex.Message);
            }

        }

        // GET api/<PagosController>/byTipoGasto/5
        [HttpGet("byTipoGasto/{tipoGastoId}")]
        [Authorize(Roles = "Administrador")]

        public IActionResult GetPagosByTipoGastoId(int tipoGastoId)
        {
            //if (HttpContext.Session.GetString("rol") != "Administrador")
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}
            if (tipoGastoId <= 0)
            {
                return StatusCode(400, "El id del tipo de gasto debe ser mayor a 0");
            }
            try
            {
                var pagos = _cUGetPagosByTipoGastoId.Execute(tipoGastoId);
                if (pagos == null || !pagos.Any())
                {
                    return StatusCode(204, "No hay pagos registrados para el tipo de gasto con id: " + tipoGastoId);
                }
                return StatusCode(200, pagos);
            }
            catch (TipoGastoExcepcion ex)
            {
                return StatusCode(404, "No se encontro el tipo de gasto con id: " + tipoGastoId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }

    }
}

