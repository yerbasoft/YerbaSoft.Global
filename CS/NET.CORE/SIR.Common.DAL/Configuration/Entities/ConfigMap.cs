using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIR.Common.DAL.Configuration.Entities
{
    internal class ConfigMap : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("CONFIG", "SIR");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ModuleId).IsRequired();
            builder.Property(x => x.Key).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Debug).IsRequired();
        }
    }
}
