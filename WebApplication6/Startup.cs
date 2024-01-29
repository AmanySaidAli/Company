using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.BL.Interface;
using WebApplication6.BL.Mapper;
using WebApplication6.BL.Reprository;
using WebApplication6.DAL.Database;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace WebApplication6
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
            // Serlization to make c# and XML be anderstaned ( Bascal , Camal)
            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }); 

            services.AddDbContextPool<DbContainer>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SharpDbConnection")));
            // everyReqouced will take inctanse
            //services.AddTransient<DepartmentRep>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
;            // evrey user will take inctanse  more useable
            services.AddScoped<IDepatmentRep,DepartmentRep>();
            services.AddScoped<IEmployeeRep, EmpolyeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();



            // one inctance taked and be shared if the window not have work only viewed for users
            //services.AddSingleton<DepartmentRep>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // take inctance from langouge 
            var supportedCultures = new[] {
              new CultureInfo("ar-EG"),
              new CultureInfo("en-US"),
      };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
