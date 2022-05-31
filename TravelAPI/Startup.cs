using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TravelAPI.Services;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using TravelAPI.Models;
using TravelAPI.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using TravelAPI.Authorization;

namespace TravelAPI
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
            services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      }));



            var authenicationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenicationSettings);
            services.AddSingleton(authenicationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                 option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
                //option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenicationSettings.JwtIssuer,
                    ValidAudience = authenicationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenicationSettings.JwtKey)),
                };
            })
        .AddCookie(options =>
        {
            options.LoginPath = "/account/google-login"; // Must be lowercase
        })
        .AddGoogle(options =>
        {
            options.ClientId = "538900883162-bi1qq85h3vpe5m7smdocsdhshj4e92p0.apps.googleusercontent.com";
            options.ClientSecret = "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"; ;
        });
            services.AddDbContext<DataBase>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddFluentValidation();
            services.AddScoped<IAuthorizationHandler, UserOperationRequirementHandler>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRezerwacjaService, RezerwacjaService>();
            services.AddScoped<IPasswordHasher<Klient>, PasswordHasher<Klient>>();
            services.AddScoped<IValidator<RegisterKlientDto>, RegisterValidator>();
            services.AddAutoMapper(this.GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();//

            app.UseStaticFiles();


            app.UseRouting();
            app.UseCors("AllowAnyOrigin");
            app.UseAuthorization();//

            app.UseEndpoints(endpoints =>
            {
                /*     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");*/
                endpoints.MapControllers();
            });

            DBInit.Seed(app);//
          //  app.UseAuthentication();//

        }
    }
}

/*
 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TravelAPI.Services;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using TravelAPI.Models;
using TravelAPI.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TravelAPI
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
            var authenicationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenicationSettings);
            services.AddSingleton(authenicationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                // option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenicationSettings.JwtIssuer,
                    ValidAudience = authenicationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenicationSettings.JwtKey)),
                };
            })
        .AddCookie(options =>
        {
            options.LoginPath = "/account/google-login"; // Must be lowercase
        })
        .AddGoogle(options =>
        {
            options.ClientId = "538900883162-bi1qq85h3vpe5m7smdocsdhshj4e92p0.apps.googleusercontent.com";
            options.ClientSecret = "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"; ;
        });
            services.AddDbContext<DataBase>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddFluentValidation();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<Klient>, PasswordHasher<Klient>>();
            services.AddScoped<IValidator<RegisterKlientDto>, RegisterValidator>();
            services.AddAutoMapper(this.GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();//

            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();//

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            DBInit.Seed(app);//
            app.UseAuthentication();//

        }
    }
}
 */
