using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Configurations
{
    public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
    {
        public void Configure(EntityTypeBuilder<Publicacion> builder)
        {
            builder.HasKey(e => e.IdPublicacion);

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.Property(e => e.Imagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Publicacion)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        }
    }
}
