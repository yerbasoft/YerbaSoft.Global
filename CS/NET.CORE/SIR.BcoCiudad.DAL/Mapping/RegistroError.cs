using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIR.Common.DAL;

namespace SIR.BcoCiudad.DAL.Mapping
{
    internal class RegistroError : IEntityTypeConfiguration<Common.Entities.RegistroError>
    {
        public void Configure(EntityTypeBuilder<Common.Entities.RegistroError> builder)
        {
            builder.ToTable("REGISTRO_ERROR", "BCOCIUDAD");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Archivo).HasMaxLength(200);
            builder.Property(x => x.Codigo);
            builder.Property(x => x.Descripcion).HasMaxLength(200);
            builder.Property(x => x.Excepcion).HasMaxLength(4000);
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Linea);
            builder.Property(x => x.UnidadProceso).HasMaxLength(20);
        }
    }
}
