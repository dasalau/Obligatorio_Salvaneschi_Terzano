using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.Dtos.MetodosDePago;
using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApp.Filter;

namespace Obligatorio.WebApp.Controllers
{
    public class PagoController : Controller
    {

        private ICUAddPagoUnico<PagoUnicoDtoAlta> _cuAddPagoUnico;
        private ICUAddPagoRecurrente<PagoRecurrenteDtoAlta> _cuAddPagoRecurrente;
        private ICUGetAll<PagosDtoListado> _cUGetAllPagos;
        private ICUGetAll<TiposDeGastoDtoListado> _cUGetAllTipoGastos;
        private ICUGetAll<MetodosDePagoDtoListado> _cUGetAllMetodosPago;
        private ICUUsuarioMontoSuperior<UsuarioDtoListado> _cUUsuarioMontoSuperior;
        private ICUGetPagosMesAnio<PagoDtoReporteMensual> _cUGetPagosMesAnio;
        public PagoController(ICUAddPagoUnico<PagoUnicoDtoAlta> cUAddPagoUnico,
                              ICUAddPagoRecurrente<PagoRecurrenteDtoAlta> cUAddPagoRecurrente,
                              ICUGetAll<PagosDtoListado> cUGetAllPagos,
                              ICUGetAll<TiposDeGastoDtoListado> cuGetAllTipoGastos,
                              ICUGetAll<MetodosDePagoDtoListado> cUGetAllMetodosPago,
                              ICUUsuarioMontoSuperior<UsuarioDtoListado> cUUsuarioMontoSuperior,
                              ICUGetPagosMesAnio<PagoDtoReporteMensual> cUGetPagosMesAnio
                              )
        {
            _cuAddPagoUnico = cUAddPagoUnico;
            _cuAddPagoRecurrente = cUAddPagoRecurrente;
            _cUGetAllPagos = cUGetAllPagos;
            _cUGetAllTipoGastos = cuGetAllTipoGastos;
            _cUGetAllMetodosPago = cUGetAllMetodosPago;
            _cUUsuarioMontoSuperior = cUUsuarioMontoSuperior;
            _cUGetPagosMesAnio = cUGetPagosMesAnio;
        }


        // GET: PagoController
        public IActionResult Index()
        {
            return View(_cUGetAllPagos.Execute());
        }

        // GET: PagoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public IActionResult CreatePagoUnico()
        {
            ViewBag.TipoGastos = _cUGetAllTipoGastos.Execute();
            ViewBag.MetodosPago = _cUGetAllMetodosPago.Execute();
            ViewBag.UsuarioId = HttpContext.Session.GetInt32("idUsuarioLogueado");
            return View();
        }

        public IActionResult CreatePagoRecurrente()
        {
            ViewBag.TipoGastos = _cUGetAllTipoGastos.Execute();
            ViewBag.MetodosPago = _cUGetAllMetodosPago.Execute();
            ViewBag.UsuarioId = HttpContext.Session.GetInt32("idUsuarioLogueado");
            return View();

        }


        // POST: PagoController/Create
        [HttpPost]

        public IActionResult CreatePagoUnico(PagoUnicoDtoAlta pagoUnicoDtoAlta)
        {
            try
            {
                _cuAddPagoUnico.Execute(pagoUnicoDtoAlta);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                ViewBag.TipoGastos = _cUGetAllTipoGastos.Execute();
                ViewBag.MetodosPago = _cUGetAllMetodosPago.Execute();
                ViewBag.UsuarioId = HttpContext.Session.GetInt32("idUsuarioLogueado");
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }


        [HttpPost]
        public IActionResult CreatePagoRecurrente(PagoRecurrenteDtoAlta pagoRecurrenteDtoAlta)
        {
            try
            {
                _cuAddPagoRecurrente.Execute(pagoRecurrenteDtoAlta);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                ViewBag.TipoGastos = _cUGetAllTipoGastos.Execute();
                ViewBag.MetodosPago = _cUGetAllMetodosPago.Execute();
                ViewBag.UsuarioId = HttpContext.Session.GetInt32("idUsuarioLogueado");
                ViewBag.Mensaje = ex.Message;
                return View();
            }

        }

        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [RolAutorizado("Gerente")]
        public IActionResult UsuarioPagoSuperior()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UsuarioPagoSuperior(double MontoPago)
        {
            try
            {
                return View("ReporteUsuarioPagoSuperior", _cUUsuarioMontoSuperior.Execute(MontoPago));
            }
            catch (ArgumentException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        [RolAutorizado("Gerente")]
        public IActionResult PagosMesAnio()
        {

            return View();
        }
        [HttpPost]
        public IActionResult PagosMesAnio(MesAnioDto dto)
        {
            try
            {
                return View("ReportePagosMesAnio", _cUGetPagosMesAnio.Execute(dto.Mes, dto.Anio));
            }
            catch (ArgumentException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
    }
}
