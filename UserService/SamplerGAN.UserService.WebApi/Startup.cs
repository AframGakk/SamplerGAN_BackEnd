﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SamplerGAN.UserService.Models.Entities;
using SamplerGAN.UserService.Repositories.Implementations;
using SamplerGAN.UserService.Repositories.Interfaces;
using SamplerGAN.UserService.Services.Interfaces;
using SamplerGAN.UserService.Services.Implementations;
using SamplerGAN.UserService.WebApi.ExceptionHandlerExtensions;

namespace SamplerGAN.UserService.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddDbContext<UserContext>(opt =>
          opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
      services.AddTransient<IUserServices, UserServices>();
      services.AddTransient<IUserRepository, UserRepository>();

      services.Configure<ApiBehaviorOptions>(opt =>
      {
        opt.SuppressModelStateInvalidFilter = true;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      // global cors policy
      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
      app.UseHttpsRedirection();
      app.UseGlobalExceptionHandler();
      app.UseMvc();
    }
  }
}
