using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Scoped services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

// bir üründe olması gereken User Scoped lar aşşağıda yer almaktadır.
// builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
// builder.Services.AddScoped<IUserService, UserService>();


// builder.Services.AddDbContext<AppDbContext>(x =>
// {
//     
//     x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
//         optionsBuilder =>
//         {
//             // optionsBuilder.MigrationsAssembly("NLayer.Repository"); 
//             optionsBuilder.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
//         });
// });

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        options => { options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); });
});


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