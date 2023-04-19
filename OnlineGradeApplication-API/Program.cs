using Microsoft.EntityFrameworkCore;
using OnlineGradeApplication_BLL;
using OnlineGradeApplication_DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IRoleRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.RoleRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IRoleRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.RoleRepository>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
});


var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<OnlineGradeApplication_DAL.Entities.OnlineGradesDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
OnlineGradeApplication_DAL.Entities.OnlineGradesDbContext context = new OnlineGradeApplication_DAL.Entities.OnlineGradesDbContext();
Console.WriteLine(context.Roles.Count());


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
