using Obligatorio.LogicaAplicacion.Dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class AddPagoUnico : ICUAddPagoUnico<PagoUnicoDtoAlta>
    {
        private IRepositorioPagos _repo;

        public AddPagoUnico(IRepositorioPagos repo)
        {
            _repo = repo;
        }


        public void Execute(PagoUnicoDtoAlta pagoUnicoDtoAlta)
        {
            //try
            //{
            Unico unico = PagosMapper.FromDtoPagosUnico(pagoUnicoDtoAlta);
            _repo.Add(unico);
            //}

            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }
    }
}
