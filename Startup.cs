using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Services;

namespace Project3_FinalExam
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
            services.AddTransient<IGetFaculty, GetFaculty>();
            services.AddTransient<IGetUnderGraduate, GetUnderGraduate>();
            services.AddTransient<IGetGraduate, GetGraduate>();
            services.AddTransient<IGetAbout, GetAbout>();
            services.AddTransient<IGetMinors, GetMinors>();
            services.AddTransient<IGetStaff, GetStaff>();
            services.AddTransient<IGetEmploymentTable, GetEmploymentTable>();
            services.AddTransient<IGetCoopTable, GetCoopTable>();
            services.AddTransient<IGetResearchInterestArea, GetResearchInterestArea>();
            services.AddTransient<IGetResearchFaculty, GetResearchFaculty>();


            services.AddControllersWithViews();
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
