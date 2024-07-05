using System.Diagnostics;
using GenConMedico.Models.Entities;
using GenConMedico.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GenConMedico.Models.Contexts;

public class GenConMed : DbContext
{
    private readonly IConfiguration _configuration;

    public GenConMed(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public DbSet<Medico> Medicos => Set<Medico>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@_configuration.GetConnectionString("GenConMed"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfiguration(new MedicoConfiguration());
    }
}
