
using ApiVetShop.Dapper;
using ApiVetShop.IDapper;
using ApiVetShop.BLL;
using ApiVetShop.IBLL;
using ApiVetShop.Repository;
using ApiVetShop.IRepository;
using ApiVetShop.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//crear referencias singleton para las interfaces y sus clases.
builder.Services.AddSingleton<EncrypAPICall, EncrypAPICall>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IAppointmetsRepository, AppointmentRepository>();
builder.Services.AddSingleton<IDetailsRepository, DetailsRepository>();
builder.Services.AddSingleton<IUsersRepository, UserRepository>();
builder.Services.AddSingleton<IAppoinmentsBLL, AppointmentsBLL>();
builder.Services.AddSingleton<IUsersBLL, UsersBLL>();
builder.Services.AddSingleton<IDetailsBLL, DetailsBLL>();

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
