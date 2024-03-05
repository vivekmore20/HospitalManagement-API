
using HospitalApp.Models;
using HospitalApp.Repository;
using HospitalManagement.Helper;
using HospitalManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();
builder.Logging.AddConsole();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HospitalDbContext>();
builder.Services.AddAutoMapper(typeof(ApplicationModelMapping));

builder.Services.AddTransient<IPatientRepo, PatientRepo>();
builder.Services.AddTransient<IDoctorRepo,DoctorRepo>();
builder.Services.AddTransient<IAppointmentRepo,AppointmentRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
