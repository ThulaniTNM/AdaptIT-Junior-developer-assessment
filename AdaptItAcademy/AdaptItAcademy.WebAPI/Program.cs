using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using AdaptITAcademy.DataAccess.Repository;
using AdaptITAcademy.DataAccess.Repository.implementation;
using AdaptITAcademy.DataAccess.Repository.@interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// recreate all service instance for all scopes of request.
builder.Services.AddDbContext<AdaptITAcademyContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdaptItAcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddScoped(typeof(IAdaptItAcademyGenericRepository<>), typeof(AdaptItAcademyRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient< ICourseTrainingService<CourseReadDTO, CourseWriteDTO>, CourseService>();
builder.Services.AddTransient< ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO>, TrainingService>();
builder.Services.AddTransient<IRegisterDelegateService, RegisterDelegateService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
