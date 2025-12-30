using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.EquiposDeTrabajo;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApp.Filter;

namespace Obligatorio.WebApp.Controllers
{
    [RolAutorizado("Administrador", "Gerente")]

    public class UsuarioController : Controller
    {
        private ICUAddAdministrador<UsuarioDtoAlta> _cuAddAdministrador;
        private ICUAddGerente<UsuarioDtoAlta> _cuAddGerente;
        private ICUAddEmpleado<UsuarioDtoAlta> _cuAddEmpleado;
        private ICUGetAll<UsuarioDtoListado> _cuGetAllUsuarios;
        private ICUGetById<UsuarioDtoListado> _cuGetByIdUsuario;
        private ICUUpdate<UsuarioDtoAlta> _cuUpdateUsuario;
        private ICUDelete<int> _cuDeleteUsuario;
        private ICUGetAll<EquipoTrabajoDtoListado> _cuGetAllEquipoTrabajo;


        public UsuarioController(ICUAddAdministrador<UsuarioDtoAlta> cuAddAdministrador,
                                 ICUAddGerente<UsuarioDtoAlta> cuAddGerente,
                                 ICUAddEmpleado<UsuarioDtoAlta> cuAddEmpleado,
                                 ICUGetAll<UsuarioDtoListado> cuGetAllUsuarios,
                                 ICUGetById<UsuarioDtoListado> cuGetByIdUsuario,
                                 ICUUpdate<UsuarioDtoAlta> cuUpdateUsuario,
                                 ICUDelete<int> cUDelete,
                                 ICUGetAll<EquipoTrabajoDtoListado> cuGetAllEquipoTrabajo)
        {
            _cuAddAdministrador = cuAddAdministrador;
            _cuAddGerente = cuAddGerente;
            _cuAddEmpleado = cuAddEmpleado;
            _cuGetAllUsuarios = cuGetAllUsuarios;
            _cuGetByIdUsuario = cuGetByIdUsuario;
            _cuDeleteUsuario = cUDelete;
            _cuUpdateUsuario = cuUpdateUsuario;
            _cuGetAllEquipoTrabajo = cuGetAllEquipoTrabajo;
        }


        #region 
        // GET: UsuarioController
        public IActionResult Index()
        {
            return View(_cuGetAllUsuarios.Execute());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { mensaje = "Id no puede ser nulo" });
            }
            else
            {
                UsuarioDtoListado usuarioDto = _cuGetByIdUsuario.Execute(id);
                if (usuarioDto == null)
                {
                    return RedirectToAction("Index", new { mensaje = "No se encontro el " + id });
                }
                ViewBag.Id = id;
                return View(usuarioDto);
            }
        }

        // GET: UsuarioController/Create

        public IActionResult CreateAdministrador()
        {
            ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
            return View();
        }

        public ActionResult CreateGerente()
        {
            ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
            return View();
        }

        public ActionResult CreateEmpleado()
        {
            ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
            return View();
        }

        // POST: UsuarioController/Create

        [HttpPost]
        public IActionResult CreateAdministrador(UsuarioDtoAlta usuarioDtoAlta)
        {
            try
            {
                _cuAddAdministrador.Execute(usuarioDtoAlta);
                return RedirectToAction("Index", "Home");
            }

            catch (NombreExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ApellidoExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ContraseniaExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (UsuarioExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }

        [HttpPost]
        public IActionResult CreateGerente(UsuarioDtoAlta usuarioDtoAlta)
        {
            try
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                _cuAddGerente.Execute(usuarioDtoAlta);
                return RedirectToAction("Index", "Home");
            }

            catch (NombreExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ApellidoExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ContraseniaExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (UsuarioExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult CreateEmpleado(UsuarioDtoAlta usuarioDtoAlta)
        {
            try
            {
                _cuAddEmpleado.Execute(usuarioDtoAlta);
                return RedirectToAction("Index");
            }

            catch (NombreExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ApellidoExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (ContraseniaExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }


            catch (UsuarioExcepcion ex)
            {
                ViewBag.EquiposDeTrabajo = _cuGetAllEquipoTrabajo.Execute();
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }

        #endregion

        // GET: UsuarioController/Edit/5
        public IActionResult Edit(int id)
        {
            UsuarioDtoListado usuarioDto = _cuGetByIdUsuario.Execute(id);
            if (usuarioDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontro el " + id });
            }

            UsuarioDtoAlta usuarioDtoAlta = new UsuarioDtoAlta(Nombre: usuarioDto.Nombre,
                                                                Apellido: usuarioDto.Apellido,
                                                                Contrasenia: usuarioDto.Contrasenia,
                                                                Email: usuarioDto.Email,
                                                                EquipoTrabajoId: usuarioDto.EquipoTrabajoId
                                                                );


            ViewBag.Id = id;
            return View(usuarioDtoAlta);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]

        public IActionResult Edit(int id, UsuarioDtoAlta usuarioDtoAlta)
        {
            try
            {
                _cuUpdateUsuario.Execute(id, usuarioDtoAlta);
                return RedirectToAction("Index", new { mensaje = "Modificacion exitosa" });
            }

            catch (NombreExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            catch (ApellidoExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            catch (ContraseniaExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            catch (UsuarioExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            //catch (Exception e)
            //{
            //    return RedirectToAction("Index", new { mensaje = e.Message });
            //}
        }

        #region

        // GET: UsuarioController/Delete/5
        public IActionResult Delete(int id)
        {
            UsuarioDtoListado usuarioDto = _cuGetByIdUsuario.Execute(id);
            if (usuarioDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontro el usuario con id: " + id });
            }

            ViewBag.Id = id;
            return View(usuarioDto);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id, UsuarioDtoListado usuarioDto)
        {

            try
            {
                _cuDeleteUsuario.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        #endregion
    }
}
