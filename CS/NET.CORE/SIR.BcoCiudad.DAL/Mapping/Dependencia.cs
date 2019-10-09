using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIR.BcoCiudad.DAL.Mapping
{
    internal class Dependencia : IEntityTypeConfiguration<Common.Entities.Dependencia>
    {
        public void Configure(EntityTypeBuilder<Common.Entities.Dependencia> builder)
        {
            builder.ToTable("DEPENDENCIA", "BCOCIUDAD");

            builder.HasKey(x => x.Id);

            //builder.HasOne<Common.Entities.Encabezado>("ENCABEZADO_ID");

            builder.Property(x => x.CantidadTalones).HasColumnName("CANT_TALONES").IsRequired();
            builder.Property(x => x.CodIntegrador).HasColumnName("COD_INTEGRADOR").IsRequired();
            builder.Property(x => x.CodTransaccion).HasColumnName("COD_TRANSACCION").IsRequired();
            builder.Property(x => x.DenominaCodIntegrador).HasColumnName("DENOM_COD_INTEGRADOR").IsRequired();
            builder.Property(x => x.FechaAcreditacion).HasColumnName("FECHA_ACREDITACION").IsRequired();
            builder.Property(x => x.ImporteAcreditado).HasColumnName("IMPORTE_ACREDITADO").IsRequired();
            builder.Property(x => x.ImporteComision).HasColumnName("IMPORTE_COMISION").IsRequired();
            builder.Property(x => x.MarcaGrabacion).HasColumnName("MARCA_GRABACION").IsRequired();
            builder.Property(x => x.MarcaProceso).HasColumnName("MARCA_PROCESO").IsRequired();
            builder.Property(x => x.NroCuenta).HasColumnName("NRO_CUENTA").IsRequired();
            builder.Property(x => x.NroDependencia).HasColumnName("NRO_DEPENDENCIA").IsRequired();
            builder.Property(x => x.NroLote).HasColumnName("NRO_LOTE").IsRequired();
            builder.Property(x => x.Referencia).HasColumnName("REFERENCIA").IsRequired();
        }
    }
}
