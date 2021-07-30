using Bader.Application;
using Domain.Entities.General;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;

namespace ERP_API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP_API", Version = "v1" });
            });
            // Add mulit Languages support
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<System.Globalization.CultureInfo>
                {
                    new System.Globalization.CultureInfo("ar-EG"),
                    new System.Globalization.CultureInfo("en-US")
                };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
                {
                    var defaultLang = "en-US";
                    var lang = context.Request.Headers["Accept-Language"].ToString();
                    if (!string.IsNullOrWhiteSpace(lang) && lang.ToString().Length > 4 && lang.ToString().Substring(2, 1) == "-")
                        defaultLang = lang.ToString().Substring(0, 5);

                    return Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            //add database
            ConfigureDatabase(services);
            //add auto mapper
            services.AddAutoMapper(typeof(MappingProfileBase));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            var options = app.ApplicationServices.GetService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP API"));
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
        // configration services methods method
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ERPDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ERPDBConnStr"));
                options.EnableSensitiveDataLogging();

            });

            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddEntityFrameworkStores<ERPDbContext>()
            //    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToAccessDenied = ReplaceRedirector(HttpStatusCode.Forbidden, options.Events.OnRedirectToAccessDenied);
                options.Events.OnRedirectToLogin = ReplaceRedirector(HttpStatusCode.Unauthorized, options.Events.OnRedirectToLogin);
            });
        }
        static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(HttpStatusCode statusCode, Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector) =>
           context =>
           {
               if (context.Request.Path.StartsWithSegments("/api"))
               {
                   context.Response.StatusCode = (int)statusCode;
                   return Task.CompletedTask;
               }
               return existingRedirector(context);
           };
    }
}
