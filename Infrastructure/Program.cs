using Application.Interfaces.Repository;
using Application.Mappers;
using Application.Services;
using Infrastructure.Dal.EntityFrameworkCore;
using Infrastructure.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ISheduleRepository, SheduleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SheduleService>();
builder.Services.AddAutoMapper(typeof(UserProfile), typeof(SheduleProfile));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; // Укажи адрес Redis-сервера
});
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();