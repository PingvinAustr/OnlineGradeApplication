using Microsoft.EntityFrameworkCore;
using OnlineGradeApplication_BLL;
using OnlineGradeApplication_DAL;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://www.contoso.com")

                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                          .WithMethods("PUT", "DELETE", "GET", "POST");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IRoleRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.RoleRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IRoleRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.RoleRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IAssignmentTypeRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.AssignmentTypeRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IAssignmentTypeRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.AssignmentTypeRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.ICafedraRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.CafedraRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.ICafedraRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.CafedraRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IDisciplineRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.DisciplineRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IDisciplineRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.DisciplineRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IGroupRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.GroupRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IGroupRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.GroupRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IPersonRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.PersonRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IPersonRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.PersonRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentAssignmentRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentAssignmentRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentAssignmentRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentAssignmentRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentCardRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentCardRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentCardRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentCardRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentMarkRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentMarkRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentMarkRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentMarkRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentsGroupRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentsGroupsRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentGroupsRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentsGroupsRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentStatusRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentStatusRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentStatusRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentStatusRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.ISystemAccessRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.SystemAccessRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.ISystemAccessRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.SystemAccessRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherCardRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.TeacherCardRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.ITeacherCardRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.TeacherCardRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeachersGroupRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.TeachersGroupRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.ITeachersGroupRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.TeacherGroupRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherPositionRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.TeacherPositionRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.ITeacherPositionRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.TeacherPositionRepository>();

builder.Services.AddScoped<OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentMarkRepository, OnlineGradeApplication_DAL.Interfaces.Implementations.StudentMarkRepository>();
builder.Services.AddScoped<OnlineGradeApplication_BLL.Interfaces.Abstractions.IStudentMarkRepository, OnlineGradeApplication_BLL.Interfaces.Implementations.StudentMarkRepository>();


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
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
