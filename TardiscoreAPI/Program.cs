using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Net;
using System.Text;
using TardiscoreAPI.Data;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var jwtIssuer = configuration.GetSection("Jwt:Issuer").Value;
var jwtAudience = configuration.GetSection("Jwt:Audience").Value;
var jwtKey = configuration.GetSection("Jwt:Key").Value;
var supportedCultures = new[]
{
    new CultureInfo("fr-FR"),
    new CultureInfo("en-US")
};

if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience) || string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT configuration values are missing");
}

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.FromSeconds(5)
        };
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("fr-FR");
    options.SupportedCultures = supportedCultures;
});

builder.Services.AddControllers();

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddScoped<IResourcesService, ResourcesService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Define the error handling endpoint
app.Map("/error", app =>
{
    app.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "text/html";

        await context.Response.WriteAsync("<html><body>\r\n");
        await context.Response.WriteAsync("An unexpected error occurred. Please try again later or contact support.\r\n");
        await context.Response.WriteAsync("</body></html>\r\n");
    });
});

app.Run();