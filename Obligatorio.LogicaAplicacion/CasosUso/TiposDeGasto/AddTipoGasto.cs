using Obligatorio.LogicaAplicacion.Dtos.TiposDeGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposDeGasto
{
    public class AddTipoGasto : ICUAddTipoGastoWithLog<TiposDeGastoDtoAlta>
    {
        private IRepositorioTipoGasto _repo;
        private IRepositorioLog _repoLog;

        public AddTipoGasto(IRepositorioTipoGasto repo, IRepositorioLog repoLog)
        {
            _repo = repo;
            _repoLog = repoLog;
        }
        public void Execute(TiposDeGastoDtoAlta dto, int idUsuario)
        {
            if (dto == null)
            {
                throw new DescripcionExcepcion("Los datos recibidos no son correctos");
            }

            try
            {
                TipoGasto obj = TipoDeGastoMapper.FromDto(dto);
                _repo.Add(obj);
                _repoLog.Add(new Log("Alta TipoGasto", DateTime.Now, idUsuario));

            }

            catch (TipoGastoExcepcion ex)
            {
                {
                    throw new DescripcionExcepcion(ex.Message);
                }

            }
        }
    }
}
