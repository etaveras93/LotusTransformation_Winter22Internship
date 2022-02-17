using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LotusTransformation.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LotusTransformation.Data;


namespace LotusTransformation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        { 
            this.Configuration = configuration; ;
        }

        private IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<UserSignUpVM>();
            services.AddScoped<ExistingUserVM>();
            services.AddMvcCore().AddRazorRuntimeCompilation();
            services.AddDbContext<LotusTransformationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LotusTransformationDb")));
            
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}",
                    defaults: new
                    {
                        controller = "LotusGeneral",
                        action = "Home"
                    });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "CreateAccount",
                    pattern: "{controller}/{action}",
                    defaults: new
                    {
                        controller = "CreateAccount",
                        action = "CreateAccount"
                    });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "SignIn",
                    pattern: "{controller}/{action}",
                    defaults: new
                    {
                        controller = "SignIn",
                        action = "SignIn"
                    });
            });


        }
    }
}
