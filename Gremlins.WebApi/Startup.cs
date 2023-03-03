using AutoMapper;
using Gremlins.WebApi.Application;
using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.DataAccess;
using Gremlins.WebApi.DataAccess.Repositories;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWebsocketHandlerApplication, WebsocketHandlerApplication>();
            services.AddControllers();

            services.AddDbContext<GremlinsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PruebaDigitalware")));


            #region DI DataAccess
            services.AddTransient<IUserAdminRepository, UserAdminRepository>();
            services.AddTransient<IPartidoRepository, PartidoRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<ISesionRepository, SesionRepository>();
            services.AddTransient<IClientesRepository, ClientesRepository>();
            #endregion

            #region DI Application
            services.AddTransient<IUserAdminApplication, UserAdminApplication>();
            services.AddTransient<IPartidoApplication, PartidoApplication>();
            services.AddTransient<IPaisApplication, PaisApplication>();
            services.AddTransient<ISesionApplication, SesionApplication>();
            services.AddTransient<IClientesApplication, ClientesAppplication>();
            #endregion




            // Configuracion Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gremlins.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gremlins.WebApi v1"));
            }

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            //app.UseHttpsRedirection();
            app.UseWebSockets();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
