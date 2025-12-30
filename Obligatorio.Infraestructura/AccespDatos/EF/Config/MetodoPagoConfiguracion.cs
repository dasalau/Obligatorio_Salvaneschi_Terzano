using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccespDatos.EF.Config
{
    public class MetodoPagoConfiguracion : IEntityTypeConfiguration<MetodoPago>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MetodoPago> builder)
        {
            builder
                .HasDiscriminator<string>("Metodo")
                .HasValue<Credito>("Credito")
                .HasValue<Contado>("Contado");

        }


    }
}





