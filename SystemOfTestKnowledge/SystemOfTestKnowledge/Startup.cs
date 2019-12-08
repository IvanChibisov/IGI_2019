using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SystemOfTestKnowledge.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace SystemOfTestKnowledge
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddDbContext<SystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SystemContext>();

            services.AddMvc()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<Chat>("/Chat");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "settinguser",
                    template: "/UserSetting/{id?}",
                    defaults: new { controller = "Users", action = "UserSetting" }
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "question",
                    template: "/Test/Questions/{controller=Question}/{action=EditQuestion}/{id?}");
                routes.MapRoute(
                    name: "testlist",
                    template: "/Tests/TestList/{id?}",
                    defaults: new { controller = "Tests", action = "TestList"}
                    );
                routes.MapRoute(
                    name: "role_userslist",
                    template: "/RoleUserList",
                    defaults: new { controller = "Roles", action = "UserList" }
                    );
                routes.MapRoute(
                    name: "account_logoff",
                    template: "/Account/{id?}",
                    defaults: new { controller = "Account", action = "Index" }
                    );
                routes.MapRoute(
                    name: "userlist",
                    template: "/UserList",
                    defaults: new { controller = "Users", action = "Index" }
                    );
                routes.MapRoute(
                    name: "privacy",
                    template: "/Privacy",
                    defaults: new { controller = "Home", action = "Privacy" }
                    );
                routes.MapRoute(
                    name: "login",
                    template: "/Login",
                    defaults: new { controller = "Account", action = "Login" }
                    );
                routes.MapRoute(
                    name: "register",
                    template: "/Register",
                    defaults: new { controller = "Account", action = "Register" }
                    );
                routes.MapRoute(
                    name: "home",
                    template: "/",
                    defaults: new { controller = "Home", action = "Index" }
                    );               
                routes.MapRoute(
                    name: "create_role",
                    template: "/Role_Create",
                    defaults: new { controller = "Roles", action = "Create" }
                    );
                routes.MapRoute(
                    name: "edit_users_role",
                    template: "/Edit_Role/{id?}",
                    defaults: new { controller = "Roles", action = "Edit" }
                    );
                routes.MapRoute(
                    name: "roles",
                    template: "/Roles",
                    defaults: new { controller = "Roles", action = "Index" }
                    );
                routes.MapRoute(
                    name: "add_question",
                    template: "/Add_Question",
                    defaults: new { controller = "Question", action = "AddQuestion" }
                    );
                routes.MapRoute(
                    name: "add_test",
                    template: "/Add_Test",
                    defaults: new { controller = "Tests", action = "AddTest" }
                    );
                routes.MapRoute(
                    name: "end_test",
                    template: "/Result",
                    defaults: new { controller = "Tests", action = "EndTest" }
                    );
                routes.MapRoute(
                    name: "start_test",
                    template: "/Test/{id?}",
                    defaults: new { controller = "Tests", action = "StartTest" }
                    );
                routes.MapRoute(
                    name: "change_password",
                    template: "/Change_password/{id?}",
                    defaults: new { controller = "Users", action = "ChangePassword" }
                    );
                routes.MapRoute(
                    name: "change_password_admin",
                    template: "/Change_password(admin)/{id?}",
                    defaults: new { controller = "Users", action = "ChangePasswordAdmin" }
                    );
                routes.MapRoute(
                    name: "create_user",
                    template: "/Create_User",
                    defaults: new { controller = "Users", action = "Create" }
                    );
                routes.MapRoute(
                    name: "edit_user",
                    template: "/Edit_User/{id?}",
                    defaults: new { controller = "Users", action = "Edit" }
                    );
                routes.MapRoute(
                    name: "questionlist",
                    template: "/Question_List/{id?}",
                    defaults: new { controller = "Tests", action = "QuestionsList" }
                    );
            });
        }
    }
}
