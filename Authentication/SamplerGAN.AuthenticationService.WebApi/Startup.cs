using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SamplerGAN.AuthenticationService.WebApi.ExceptionHandlerExtensions;
using SamplerGAN.AuthenticationService.WebApi.Helpers;
using SamplerGAN.AuthenticationService.WebApi.Models.Entities;
using SamplerGAN.AuthenticationService.WebApi.Repositories;
using SamplerGAN.AuthenticationService.WebApi.Services;

namespace SamplerGAN.AuthenticationService.WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors ();
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.AddDbContext<UserContext> (opt =>
                opt.UseNpgsql (Configuration.GetConnectionString ("DefaultConnection")));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection ("AppSettings");
            services.Configure<AppSettings> (appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings> ();
            var key = Encoding.ASCII.GetBytes (appSettings.Secret);
            services.AddAuthentication (x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey (key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<ILoginService, LoginService> ();
            services.AddTransient<IAuthRepository, AuthRepository> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            // global cors policy
            app.UseCors (x => x
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());

            app.UseAuthentication ();
            app.UseGlobalExceptionHandler ();
            app.UseMvc ();
        }
    }
}