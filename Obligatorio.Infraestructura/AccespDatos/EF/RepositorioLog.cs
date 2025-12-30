using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class RepositorioLog : IRepositorioLog
    {
        private ObligatorioContext _context { get; set; }

        public RepositorioLog(ObligatorioContext context)
        {
            _context = context;
        }

        public RepositorioLog()
        {
        }

        public void Add(Log obj)
        {
            _context.Logs.Add(obj);
            _context.SaveChanges();
        }
    }
}
