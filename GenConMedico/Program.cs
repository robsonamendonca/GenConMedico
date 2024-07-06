using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.Validators.Consultas;
using GenConMedico.Validators.Medicos;
using GenConMedico.Validators.MonitoramentoPaciente;
using GenConMedico.Validators.Pacientes;
using GenConMedico.ViewModels.Consultas;
using GenConMedico.ViewModels.Medicos;
using GenConMedico.ViewModels.MonitoramentoPaciente;
using GenConMedico.ViewModels.Pacientes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddDbContext<GenConMedContext>();
builder.Services.AddScoped<IValidator<AdicionarMedicoViewModel>, AdicionarMedicoValidator>();
builder.Services.AddScoped<IValidator<EditarMedicoViewModel>, EditarMedicoValidator>();
builder.Services.AddScoped<IValidator<AdicionarPacienteViewModel>, AdicionarPacienteValidator>();
builder.Services.AddScoped<IValidator<EditarPacienteViewModel>, EditarPacienteValidator>();
builder.Services.AddScoped<IValidator<AdicionarMonitoramentoViewModel>, AdicionarMonitoramentoValidator>();
builder.Services.AddScoped<IValidator<EditarMonitoramentoViewModel>, EditarMonitoramentoValidator>();
builder.Services.AddScoped<IValidator<AdicionarConsultaViewModel>, AdicionarConsultaValidator>();
builder.Services.AddScoped<IValidator<EditarConsultaViewModel>, EditarConsultaValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
