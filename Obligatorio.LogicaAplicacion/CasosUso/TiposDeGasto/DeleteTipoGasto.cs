using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto
{
    public class DeleteTipoGasto : ICUDeleteWithLog<TiposDeGastoDtoAlta>
    {
        private IRepositorioTipoGasto _repo;
        private IRepositorioLog _repoLog;
        private IRepositorioPagos _repoPagos;


        public DeleteTipoGasto(IRepositorioTipoGasto repo, IRepositorioLog repoLog, IRepositorioPagos repoPagos)
        {
            _repo = repo;
            _repoLog = repoLog;
            _repoPagos = repoPagos;
        }
        public void Execute(int id, int idUsuario)
        {
            var pagoAsociado = _repoPagos.GetAll()
                .FirstOrDefault(p => p.TipoGasto.Id == id);

            if (pagoAsociado != null)
            {
                throw new TipoGastoExcepcion("No se puede eliminar el Tipo de Gasto porque existen Pagos asociados a él.");
            }

            _repo.Delete(id);
            _repoLog.Add(new Log("Baja TipoGasto", DateTime.Now, idUsuario));
        }
    }
}
