using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto
{
    public class UpdateTipoGasto : ICUUpdateWithLog<TiposDeGastoDtoAlta>

    {
        private IRepositorioTipoGasto _repo;
        private IRepositorioLog _repoLog;

        public UpdateTipoGasto(IRepositorioTipoGasto repo, IRepositorioLog repoLog)
        {
            _repo = repo;
            _repoLog = repoLog;
        }

        public void Execute(int id, TiposDeGastoDtoAlta Obj, int idUsuario)
        {
            _repo.Update(id, TipoDeGastoMapper.FromDto(Obj));
            _repoLog.Add(new Log("Modificacion TipoGasto", DateTime.Now, idUsuario));

        }
    }
}
