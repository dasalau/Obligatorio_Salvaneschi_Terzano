using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioEquipoTrabajo : IRepositorioEquipoTrabajo
    {
        private ObligatorioContext _context;
        public RepositorioEquipoTrabajo(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(EquipoTrabajo obj)
        {
            // Validar
            _context.EquiposTrabajo.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipoTrabajo> GetAll()
        {
            return _context.EquiposTrabajo;
        }

        public EquipoTrabajo GetById(int id)
        {
            EquipoTrabajo unEquipoTrabajo = _context.EquiposTrabajo.FirstOrDefault(equipoTrabajo => equipoTrabajo.Id == id);
            if (unEquipoTrabajo == null)
            {
                throw new Exception("No se encontro el id");
            }
            return unEquipoTrabajo;
        }

        public void Update(int id, EquipoTrabajo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipoTrabajo> GetEquiposPagosUnicosByMonto(double monto)
        {
            var resultado = _context.Pagos
                .Include(p => p.Usuario)
                .ThenInclude(u => u.EquipoTrabajo)
                .Where(p => p.Discriminator == "Unico" && p.MontoPago > monto)
                .Select(p => p.Usuario.EquipoTrabajo)
                .Distinct();

            return resultado;
        }

    }
}
