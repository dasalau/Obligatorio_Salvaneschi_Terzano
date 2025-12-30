using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{

    public class AddPagoRecurrente : ICUAddPagoRecurrente<PagoRecurrenteDtoAlta>
    {
        private IRepositorioPagos _repo;

        public AddPagoRecurrente(IRepositorioPagos repo)
        {
            _repo = repo;
        }

        public void Execute(PagoRecurrenteDtoAlta pagoRecurrenteDtoAlta)
        {
            //try
            //{
            if (pagoRecurrenteDtoAlta.FechaDesde > pagoRecurrenteDtoAlta.FechaHasta)
            {
                throw new PagosExcepcion("La fecha Desde no puede ser mayor a la fecha Hasta.");
            }

            Recurrente recurrente = PagosMapper.FromDtoPagosRecurrente(pagoRecurrenteDtoAlta);
            _repo.Add(recurrente);
            //}

            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }
    }

}
