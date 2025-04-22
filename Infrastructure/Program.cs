using Application.Interfaces.Repository;
using Application.Mappers;
using Application.Services;
using Infrastructure.Dal.EntityFrameworkCore;
using Infrastructure.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Repository

builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ISheduleRepository, SheduleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

#endregion

#region Other

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null);
        }));
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Services

builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SheduleService>();

#endregion

#region Mapper

builder.Services.AddAutoMapper(typeof(UserProfile), typeof(SheduleProfile),typeof(LessonProfile),typeof(GroupProfile));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; 
});

#endregion

#region StartUp

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion