using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApp.Filter;

namespace Obligatorio.WebApp.Controllers
{
    [RolAutorizado("Administrador")]
    public class TipoGastoController : Controller
    {
        private ICUAddTipoGastoWithLog<TiposDeGastoDtoAlta> _cuAddTipoDeGasto;
        private ICUGetAll<TiposDeGastoDtoListado> _cuGetAllTiposDeGasto;
        private ICUGetById<TiposDeGastoDtoListado> _cuGetByIdTiposDeGasto;
        private ICUDeleteWithLog<TiposDeGastoDtoAlta> _cuDeleteTiposDeGasto;
        private ICUUpdateWithLog<TiposDeGastoDtoAlta> _cuUpdateTipoDeGasto;

        public TipoGastoController(ICUAddTipoGastoWithLog<TiposDeGastoDtoAlta> cuAddTipoDeGasto,
                                   ICUGetAll<TiposDeGastoDtoListado> cuGetAllTiposDeGasto,
                                   ICUGetById<TiposDeGastoDtoListado> cuGetByIdTiposDeGasto,
                                   ICUDeleteWithLog<TiposDeGastoDtoAlta> cuDeleteTiposDeGasto,
                                   ICUUpdateWithLog<TiposDeGastoDtoAlta> cuUpdateTipoDeGasto)
        {
            _cuAddTipoDeGasto = cuAddTipoDeGasto;
            _cuGetAllTiposDeGasto = cuGetAllTiposDeGasto;
            _cuGetByIdTiposDeGasto = cuGetByIdTiposDeGasto;
            _cuDeleteTiposDeGasto = cuDeleteTiposDeGasto;
            _cuUpdateTipoDeGasto = cuUpdateTipoDeGasto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_cuGetAllTiposDeGasto.Execute());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { mensaje = "Id no puede ser nulo" });
            }
            else
            {
                TiposDeGastoDtoListado tipogasto = _cuGetByIdTiposDeGasto.Execute(id);
                if (tipogasto == null)
                {
                    return RedirectToAction("Index", new { mensaje = "No se encontro el " + id });
                }
                ViewBag.Id = id;
                return View(tipogasto);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TiposDeGastoDtoAlta tiposDeGastoDtoAlta)
        {
            try
            {
                _cuAddTipoDeGasto.Execute(tiposDeGastoDtoAlta, (int)HttpContext.Session.GetInt32("idUsuarioLogueado"));
                return RedirectToAction("Index");
            }
            catch (DescripcionExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TiposDeGastoDtoListado tipogasto = _cuGetByIdTiposDeGasto.Execute(id);
            if (tipogasto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontro el " + id });
            }
            ViewBag.Id = id;
            return View(tipogasto);
        }

        [HttpPost]
        public IActionResult Edit(int id, TiposDeGastoDtoAlta tipoDeGastoDtoAlta)
        {
            try
            {
                _cuUpdateTipoDeGasto.Execute(id, tipoDeGastoDtoAlta, (int)HttpContext.Session.GetInt32("idUsuarioLogueado"));
                return RedirectToAction("Index", new { mensaje = "Modificacion exitosa" });
            }

            catch (DescripcionExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TiposDeGastoDtoListado tipoGasto = _cuGetByIdTiposDeGasto.Execute(id);
            if (tipoGasto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontro el " + id });
            }
            ViewBag.Id = id;
            return View(tipoGasto);
        }

        [HttpPost]
        public IActionResult Delete(int id, TiposDeGastoDtoListado tipoGastoDtoListado)
        {
            try
            {
                _cuDeleteTiposDeGasto.Execute(id, (int)HttpContext.Session.GetInt32("idUsuarioLogueado"));
                return RedirectToAction(nameof(Index));
            }
            catch (TipoGastoExcepcion ex)
            {
                ViewBag.Mensaje = ex.Message;

                //return RedirectToAction("Index");
                return View(tipoGastoDtoListado);
            }

            catch (Exception ex)
            {
                ViewBag.Mensaje = "No se pudo eliminar el tipo de gasto. " + ex.Message;
                return View(tipoGastoDtoListado);
            }
        }
    }
}
