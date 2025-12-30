using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
        private ObligatorioContext _context;
        public RepositorioTipoGasto(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(TipoGasto obj)
        {
            // Validar si ya no existe un TipoGasto con la misma descripción
            if (Exists(obj))
            {
                throw new TipoGastoExcepcion("El tipo de gasto ya existe");
            }
            _context.TipoGastos.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TipoGasto? tipoGasto = GetById(id);

            if (tipoGasto == null)
            {
                throw new TipoGastoExcepcion("No se encontro el id");
            }

            _context.TipoGastos.Remove(tipoGasto);
            _context.SaveChanges();

        }

        public IEnumerable<TipoGasto> GetAll()
        {
            return _context.TipoGastos;
        }

        public TipoGasto GetById(int id)
        {
            TipoGasto? unTipoGasto = _context.TipoGastos.FirstOrDefault(tipoGastos => tipoGastos.Id == id);
            if (unTipoGasto == null)
            {
                throw new TipoGastoExcepcion("No se encontro el id");
            }
            return unTipoGasto;
        }

        public void Update(int id, TipoGasto obj)
        {
            TipoGasto tipoGasto = GetById(id);
            if (tipoGasto == null)
            {
                throw new TipoGastoExcepcion($"TipoGasto con Id {id} no encontrado.");
            }
            // Actualizar solo la descripción del gasto
            tipoGasto.Descripcion = obj.Descripcion;
            _context.TipoGastos.Update(tipoGasto);
            _context.SaveChanges();
        }

        public bool Exists(TipoGasto obj)
        {
            return _context.TipoGastos.Any(tg => tg.Descripcion.Value.ToLower() == obj.Descripcion.Value.ToLower());
        }
    }
}
