using FluentValidation;
using GenConMedico.Models.Contexts;
using GenConMedico.Validators.Medicos;
using GenConMedico.ViewModels.Medicos;
using GenConMedico.Validators.Pacientes;
using GenConMedico.ViewModels.Pacientes;
using AdicionarViewModelMed = GenConMedico.ViewModels.Medicos.AdicionarViewModel;
using EditarViewModalMed = GenConMedico.ViewModels.Medicos.EditarViewModal;

using AdicionarViewModelPac = GenConMedico.ViewModels.Pacientes.AdicionarViewModel;
using EditarViewModalMedPac = GenConMedico.ViewModels.Pacientes.EditarViewModal;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddDbContext<GenConMed>();
builder.Services.AddScoped<IValidator<AdicionarViewModelMed>, AdicionarMedicoValidator>();
builder.Services.AddScoped<IValidator<EditarViewModalMed>, EditarMedicoValidator>();

builder.Services.AddScoped<IValidator<AdicionarViewModelPac>, AdicionarPacienteValidator>();
builder.Services.AddScoped<IValidator<EditarViewModalMedPac>, EditarPacienteValidator>();


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
