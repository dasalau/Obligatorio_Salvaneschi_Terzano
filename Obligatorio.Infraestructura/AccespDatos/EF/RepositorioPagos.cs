using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioPagos : IRepositorioPagos
    {
        private ObligatorioContext _context;

        public RepositorioPagos(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Pagos obj)
        {
            // Validar
            _context.Pagos.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagos> GetAll()
        {
            return _context.Pagos.Include(p => p.TipoGasto).Include(p => p.MetodoPago).ToList();
        }

        public Pagos GetById(int id)
        {
            Pagos unPago = _context.Pagos.Include(p => p.TipoGasto).Include(p => p.MetodoPago)
                .FirstOrDefault(pagos => pagos.Id == id);

            if (unPago == null)
            {
                throw new PagosExcepcion("No se encontro el id");
            }
            return unPago;
        }

        public void Update(int id, Pagos obj)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Pagos obj)
        {
            return _context.Pagos.Any(p => p.Id == obj.Id);
        }

        public IEnumerable<Pagos> GetPagosByUsuarioId(int usuarioId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);
            if (usuario == null)
            {
                throw new UsuarioExcepcion("El usuario no existe");
            }

            return _context.Pagos
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.TipoGasto)
                .Include(p => p.MetodoPago)
                .ToList();
        }

        public IEnumerable<Pagos> GetPagosByTipoGastoId(int tipoGastoId)
        {
            var tipoGasto = _context.TipoGastos.Find(tipoGastoId);
            if (tipoGasto == null)
            {
                throw new TipoGastoExcepcion("El tipo de gasto no existe");
            }

            return _context.Pagos
                .Where(p => p.TipoGastoId == tipoGastoId)
                .ToList();

        }
    }
}
