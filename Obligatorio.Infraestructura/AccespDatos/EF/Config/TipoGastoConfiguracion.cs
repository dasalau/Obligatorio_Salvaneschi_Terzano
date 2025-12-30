using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccespDatos.EF.Config
{
    public class TipoGastoConfiguracion : IEntityTypeConfiguration<TipoGasto>
    {
        public void Configure(EntityTypeBuilder<TipoGasto> builder)
        {
            builder.OwnsOne(tipoGasto => tipoGasto.Descripcion, VoDescripcion =>
            {
                VoDescripcion.Property(p => p.Value).HasColumnName("Descripcion");
            }
          );
        }
    }
}
