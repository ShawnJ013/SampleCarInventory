using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerShip.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DealerShip
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
            services.AddCors(options =>

            {
                options.AddPolicy("CorsPolicy",

                    builder => builder.AllowAnyOrigin()

                    .AllowAnyMethod()

                    .AllowAnyHeader()

                    .AllowCredentials());

            });
            services.AddMvc();

            services.AddDbContext<VehiclesContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("VehiclesContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
