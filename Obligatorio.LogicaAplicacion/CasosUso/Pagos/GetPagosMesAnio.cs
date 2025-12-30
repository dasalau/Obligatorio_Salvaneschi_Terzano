using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetPagosMesAnio : ICUGetPagosMesAnio<PagoDtoReporteMensual>
    {
        private IRepositorioPagos _repoPagos;

        public GetPagosMesAnio(IRepositorioPagos repo)
        {
            _repoPagos = repo;
        }

        public IEnumerable<PagoDtoReporteMensual> Execute(int mes, int anio)
        {
            DateTime fechaAux;
            try
            {
                fechaAux = new DateTime(anio, mes, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("Mes y/o año inválidos.");
            }

            var pagos = _repoPagos.GetAll();
            var pagosFiltrados = pagos
                .Where(p => (p is Unico pu && pu.FechaPago.Month == mes && pu.FechaPago.Year == anio)
                          || (p is Recurrente pr && pr.FechaDesde <= fechaAux && pr.FechaHasta >= fechaAux))
                .ToList();


            return PagosMapper.ToListDtoReporte(pagosFiltrados);
        }
    }
}
