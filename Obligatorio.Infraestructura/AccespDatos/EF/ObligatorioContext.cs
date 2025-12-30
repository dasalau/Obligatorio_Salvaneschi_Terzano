using Microsoft.EntityFrameworkCore;
using Obligatorio.Infraestructura.AccespDatos.EF.Config;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccespDatos.EF
{
    public class ObligatorioContext : DbContext

    {
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Gerente> Gerentes { get; set; }
        //public DbSet<Administrador> Administradores { get; set; }
        //public DbSet<Empleado> Emplealdos { get; set; }
        public DbSet<EquipoTrabajo> EquiposTrabajo { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Credito> Credito { get; set; }
        public DbSet<Contado> Contado { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Unico> Unicos { get; set; }
        public DbSet<Recurrente> Recurrentes { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ObligatorioContext(DbContextOptions<ObligatorioContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EquipoTrabajoConfiguracion());
            modelBuilder.ApplyConfiguration(new MetodoPagoConfiguracion());
            modelBuilder.ApplyConfiguration(new PagosConfiguracion());
            modelBuilder.ApplyConfiguration(new TipoGastoConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        }

    }
}
