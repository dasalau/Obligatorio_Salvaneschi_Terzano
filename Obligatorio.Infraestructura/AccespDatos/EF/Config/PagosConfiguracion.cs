using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;


namespace Obligatorio.Infraestructura.AccespDatos.EF.Config

{
    public class PagosConfiguracion : IEntityTypeConfiguration<Pagos>
    {
        public void Configure(EntityTypeBuilder<Pagos> builder)
        {
            builder.OwnsOne(pago => pago.Descripcion, VoDescripcion =>
            {
                VoDescripcion.Property(p => p.Value).HasColumnName("Descripcion");

            }
            );
            builder.HasOne(tg => tg.TipoGasto)
               .WithMany()
               .HasForeignKey(tg => tg.TipoGastoId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(mp => mp.MetodoPago)
               .WithMany()
               .HasForeignKey(mp => mp.MetodoPagoId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.Usuario)
               .WithMany()
               .HasForeignKey(u => u.UsuarioId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
