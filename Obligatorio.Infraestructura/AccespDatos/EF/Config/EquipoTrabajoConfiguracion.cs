using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccespDatos.EF.Config
{
    public class EquipoTrabajoConfiguracion : IEntityTypeConfiguration<EquipoTrabajo>
    {
        public void Configure(EntityTypeBuilder<EquipoTrabajo> builder)
        {
            builder.OwnsOne(equipoTrabajo => equipoTrabajo.Nombre, VoNombre =>
            {
                VoNombre.Property(p => p.Value).HasColumnName("Nombre");
            }
           );
        }
    }
}
