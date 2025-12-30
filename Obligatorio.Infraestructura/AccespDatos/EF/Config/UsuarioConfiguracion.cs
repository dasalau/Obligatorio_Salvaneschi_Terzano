using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccespDatos.EF.Config
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


            builder.OwnsOne(usuario => usuario.Nombre, VoNombre =>
            {
                VoNombre.Property(p => p.Value).HasColumnName("Nombre");
            }
           );
            builder.OwnsOne(usuario => usuario.Apellido, VoApellido =>
            {
                VoApellido.Property(p => p.Value).HasColumnName("Apellido");
            }
           );
            builder.OwnsOne(usuario => usuario.Contrasenia, VoContrasenia =>
            {
                VoContrasenia.Property(p => p.Value).HasColumnName("Contrasenia");
            }
           );
            builder.OwnsOne(usuario => usuario.Email, VoEmail =>
            {
                VoEmail.Property(p => p.Value).HasColumnName("Email");
            }
           );

            builder
                .HasDiscriminator<string>("Rol")
                .HasValue<Gerente>("Gerente")
                .HasValue<Administrador>("Administrador")
                .HasValue<Empleado>("Empleado");

            builder.HasOne(usuario => usuario.EquipoTrabajo)
               .WithMany()
               .HasForeignKey(usuario => usuario.EquipoTrabajoId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
