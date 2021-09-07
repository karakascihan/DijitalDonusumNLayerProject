using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Data;
using Data.Repositories;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiService;

namespace Web
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
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));  //DTO iþlemi için yükledik

            services.AddHttpClient<CategoryApiService>(opt =>//api ile web haberþlmesi için
            {
                opt.BaseAddress = new Uri(Configuration["baseUrl"]);
            });

            // 1. Ýþlem connecting stringsi dahil ediyoruz. Ýlkin burada ef.Core paketini yüklemediðimiz için hata verdi
            services.AddDbContext<AppDbContext>(options =>
            {
                // options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"].ToString());
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });
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
