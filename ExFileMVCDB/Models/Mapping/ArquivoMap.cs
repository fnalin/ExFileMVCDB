using System.Data.Entity.ModelConfiguration;

namespace ExFileMVCDB.Models.Mapping
{
    public class ArquivoMap : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.AnexoBytes)
                .IsRequired();

            this.Property(t => t.AnexoExtensao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.AnexoTipo)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Arquivo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.AnexoBytes).HasColumnName("AnexoBytes");
            this.Property(t => t.AnexoExtensao).HasColumnName("AnexoExtensao");
            this.Property(t => t.AnexoTipo).HasColumnName("AnexoTipo");
        }
    }
}