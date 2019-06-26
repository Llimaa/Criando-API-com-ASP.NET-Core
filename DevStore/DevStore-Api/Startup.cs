using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevStore.Domain.StoreContext.Handles;
using DevStore.Domain.StoreContext.Repositoties;
using DevStore.Domain.StoreContext.Services;
using DevStore.Infra.Services;
using DevStore.Infra.StoreContext.DataContexts;
using DevStore.Infra.StoreContext.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using System.IO;
using DevStore.Shared;

namespace DevStore_Api
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
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerCommandHandle, CustomerCommandHandle>();



            //midle para documentar api.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Dev Store",
                    Version = "v1",
                    Description = "Documentação detalhada de todos os metodos da api.",
                    Contact = new Contact
                    {
                        Name = "Marcos Lima",
                        Url = "https://github.com/Llimaa"
                    }
                });
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";

            services.AddElmahIo(o =>
            {
                o.ApiKey = "5cd81c4a8d5c4b84a9ac3998e1bf0b52";
                o.LogId = new Guid("efcc2a0a-da89-46de-b26d-3c24d78535ac");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dev_Store_V1");
            });

            app.UseElmahIo();
        }
    }
}
