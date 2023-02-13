using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SummertimeSunshine_API.Product_Services;
using SummertimeSunshine_API.Products_Model;
using SummertimeSunshine_API.Registration_Services;
using SummertimeSunshine_API.Repo;
using SummertimeSunshine_API.User_Services;
using System.Text;

namespace SummertimeSunshine_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gheiboi"));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = true,
                ValidIssuer = "authapi",

                ValidateAudience = true,
                ValidAudience = "productapi"
            });
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection")));
            builder.Services.AddScoped<IProductlistRepo, ProductlistRepo>();
            builder.Services.AddScoped<IProductlistServices, ProductlistServices>();
            builder.Services.AddScoped<IUserlistRepo, UserlistRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



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
        }
    }
}