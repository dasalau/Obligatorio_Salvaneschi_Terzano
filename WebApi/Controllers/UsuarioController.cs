using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado> _cuUsuarioLogin;
        private ICUGetById<UsuarioDtoListado> _cuGetById;
        private ICUChangePassword<int> _cuChangePassword;

        private readonly IJwtGenerator<UsuarioDtoApi> _jwtGenerator;

        public UsuarioController(ICUUsuarioLogin<UsuarioDtoLogin, UsuarioDtoLogeado> cuUsuarioLogin,
                                 ICUGetById<UsuarioDtoListado> cUGetById,
                                 ICUChangePassword<int> cuChangePassword,
                                 IJwtGenerator<UsuarioDtoApi> jwtGenerator)
        {
            _cuUsuarioLogin = cuUsuarioLogin;
            _cuGetById = cUGetById;
            _cuChangePassword = cuChangePassword;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public Task<IActionResult> Login([FromBody] UsuarioDtoLogin usuarioDtoLogin)
        {

            try
            {
                var usuarioLogueado = _cuUsuarioLogin.Execute(usuarioDtoLogin);
                /*
                HttpContext.Session.SetString("rol", usuarioLogeado.Rol);
                HttpContext.Session.SetInt32("idUsuarioLogueado", usuarioLogeado.Id);
                return Task.FromResult<IActionResult>(Ok(usuarioLogeado));
                */

                UsuarioDtoApi usuarioDtoApi = new(usuarioLogueado.Id,
                                                  usuarioLogueado.Nombre,
                                                  usuarioLogueado.Rol);
                var token = _jwtGenerator.GenerateToken(usuarioDtoApi);
                return Task.FromResult<IActionResult>(Ok(new
                {
                    Token = token,
                    Usuario = usuarioDtoApi  // Devuelve también los datos del usuario logueado
                }));
            }
            catch (UsuarioExcepcion ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }

            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(StatusCode(500, "Error en el servidor: " + ex.Message));
            }
        }

        //[HttpPost("logout")]
        //public Task<IActionResult> Logout()
        //{
        //    if (HttpContext.Session.GetString("rol") != null)
        //    {
        //        HttpContext.Session.Clear();
        //        return Task.FromResult<IActionResult>(Ok("Sesión cerrada correctamente."));

        //    }

        //    return Task.FromResult<IActionResult>(BadRequest("No hay una sesión activa para cerrar."));

        //}


        //GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(400, "El id debe ser mayor a 0");
                }
                return StatusCode(200, _cuGetById.Execute(id));
            }

            catch (UsuarioExcepcion ex)
            {
                return StatusCode(404, "No se encontro el usuario con id: " + id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }


        //Accion para cambiar la contraseña de un usuario


        [HttpPost("changePassword/{id}")]
        [Authorize(Roles = "Administrador")]

        public IActionResult ChangePassword(int id)
        {
            //if (HttpContext.Session.GetString("rol") == null ||
            //    HttpContext.Session.GetString("rol") != "Administrador")
            //{
            //    return StatusCode(403, "No tiene permisos para realizar esta acción");
            //}

            try
            {
                if (id <= 0)
                {
                    return StatusCode(400, "El id debe ser mayor a 0");
                }

                _cuChangePassword.Execute(id);
                return StatusCode(200, $"Contraseña cambiada correctamente. {_cuGetById.Execute(id)}");
            }

            catch (UsuarioExcepcion ex)
            {
                return StatusCode(404, "No se encontro el usuario con id: " + id);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }

    }
}
