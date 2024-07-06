using Microsoft.EntityFrameworkCore;
using GenConMedico.Models.Entities;
using GenConMedico.Models.EntityConfigurations;

namespace GenConMedico.Models.Contexts
{
    public class GenConMedContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public GenConMedContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Medico> Medicos => Set<Medico>();
        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<InformacoesComplementaresPaciente> InformacoesComplementaresPaciente => Set<InformacoesComplementaresPaciente>();
        public DbSet<MonitoramentoPaciente> MonitoramentoPaciente => Set<MonitoramentoPaciente>();
        public DbSet<Consulta> Consultas => Set<Consulta>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("GenConMedico"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new InformacoesComplementaresPacienteConfiguration());
            modelBuilder.ApplyConfiguration(new MonitoramentoPacienteConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultaConfiguration());
        }
    }
}