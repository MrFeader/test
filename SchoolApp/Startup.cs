using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ninject.Modules;
using SchoolApp.BLL.Interfaces;
using SchoolApp.BLL.Services;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using SchoolApp.DAL.Repositories;

namespace SchoolApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IPupilService, PupilService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherGradeService, TeacherGradeService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUnitOfWork, EFUnitOfWork>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/api/account/login");
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(connection, b=>b.MigrationsAssembly("SchoolApp.Web"))
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
