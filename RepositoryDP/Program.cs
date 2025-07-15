using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryDP.Data;
using RepositoryDP.Repository.CategoryRepo;
using RepositoryDP.Repository.ProductRepo;
using RepositoryDP.Service.CategoryService;
using RepositoryDP.Service.ProductService;
using FluentValidation.AspNetCore;
using RepositoryDP.Validation;
using FluentValidation;
using System;
using RepositoryDP.Repository;
using RepositoryDP.Repository.UserRepo;
using RepositoryDP.Service.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RepositoryDP.Extentions;
using RepositoryDP.Service.Auth;
using RepositoryDP.Model;
using RepositoryDP.Service.Roles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//// Genaric repository ///

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();



builder.Services.AddTransient<IRoleService, RolseService>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//*********************************************************************************
// inject Connection String
builder.Services.AddDbContext<EFContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnString"));
});

builder.Services.AddScoped (typeof(IRepository<>), typeof(Repository<>));



// mapper
builder.Services.AddAutoMapper(typeof(Program));

// validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();

// adding identity
builder.Services.AddIdentity<MyUserModel, IdentityRole>()
    .AddEntityFrameworkStores<EFContext>()
    .AddDefaultTokenProviders();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "July Shop 2025", Version = "v1", Description = "Shop 2025 description" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid token in the following format: {your token here} do not add the word 'Bearer' before it."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// JWT Setting
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
    if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Key))
    {
        throw new InvalidOperationException("JWT secret key is not configured.");
    }

    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
    builder.Services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidAudience = jwtSettings.ValidAudience,
            IssuerSigningKey = secretKey
        };
        o.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    message = "You are not authorized to access this resource. Please authenticate."
                });
                return context.Response.WriteAsync(result);
            },
        };
    });
//*********************************************************************************
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
