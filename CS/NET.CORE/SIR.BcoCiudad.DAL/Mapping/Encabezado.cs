using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIR.Common.DAL;

namespace SIR.BcoCiudad.DAL.Mapping
{
    internal class Encabezado : IEntityTypeConfiguration<Common.Entities.Encabezado>
    {
        public void Configure(EntityTypeBuilder<Common.Entities.Encabezado> builder)
        {
            builder.ToTable("ENCABEZADO", "BCOCIUDAD");

            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.RegistroError);

            builder.Property(x => x.Banco).HasMaxLength(18).IsRequired();
            builder.Property(x => x.CierreZ);

            builder.Property(x => x.EsConsistente).HasColumnName("ES_CONSISTENTE").YesNoType();
            
        }
    }
}
