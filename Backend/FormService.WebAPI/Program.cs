using Commons.JWTRevoke;
using FluentValidation;
using FormService.Infrastructure;
using FormService.WebAPI.Controllers.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Zack.JWT;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 数据库配置源Zack.AnyDBConfigProvider
builder.WebHost.ConfigureAppConfiguration((hostCtx, configBuilder) =>
{
    string connStr = Environment.GetEnvironmentVariable("ConnectionStrings:SubgradeQualityForm")!;
    configBuilder.AddDbConfiguration(() => new SqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(2));
    //configBuilder.AddDbConfiguration(() => new SqlConnection(connStr), reloadOnChange: true, reloadInterval: TimeSpan.FromSeconds(2), tableName: "T_Configs_ProductEnv");  // 生产环境
});

// JWT
JWTOptions jwtOptions = builder.Configuration.GetSection("JWT").Get<JWTOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOpt =>
{
    byte[] keyBytes = Encoding.UTF8.GetBytes(jwtOptions.Key);
    var secKey = new SymmetricSecurityKey(keyBytes);
    jwtBearerOpt.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secKey,
    };
});

// DI服务注册
builder.Services.AddScoped<IJWTVersionTool, JWTVersionToolForOtherServices>();
builder.Services.AddScoped<FormRepository>();
builder.Services.AddHttpClient();  // 为了将IHttpClientFactory注入进JWTVersionToolForOtherServices


// 配置项
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));

// 筛选器
builder.Services.Configure<MvcOptions>(options =>
{
    options.Filters.Add<JWTVersionCheckFilter>();  // 判断JWT是否失效的筛选器
});

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<SubmitRequestValidator>();

// DbContext
builder.Services.AddDbContext<FormDbContext>(optionsBuilder =>
{
    string connStr = builder.Configuration.GetConnectionString("SubgradeQualityForm")!;
    optionsBuilder.UseSqlServer(connStr);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
