using GenConMedico.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenConMedico.Models.EntityConfigurations;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.CPF)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasIndex(x => x.CPF)
            .IsUnique();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.DataNascimento)
            .IsRequired();


    }

}
