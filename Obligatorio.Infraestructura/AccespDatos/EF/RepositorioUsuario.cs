using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ObligatorioContext _context;

        public RepositorioUsuario(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            // Validar
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Usuario? usuario = GetById(Id);

            if (usuario == null)
            {
                throw new UsuarioExcepcion("No se encontro el id");
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.Include(u => u.EquipoTrabajo).ToList();
        }

        public Usuario GetById(int id)
        {
            Usuario? unUsuario = _context.Usuarios.Include(u => u.EquipoTrabajo).FirstOrDefault(usuario => usuario.Id == id);
            if (unUsuario == null)
            {
                throw new UsuarioExcepcion("No se encontro el id");
            }
            return unUsuario;
        }

        public void Update(int id, Usuario usuario)
        {

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario? GetByEmail(string email)
        {
            Usuario? usuario = _context.Usuarios.Include(u => u.EquipoTrabajo).FirstOrDefault(u => u.Email.Value == email);
            return usuario;
        }
    }
}
