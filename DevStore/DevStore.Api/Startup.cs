using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevStore.Domain.StoreContext.Repositoties;
using DevStore.Domain.StoreContext.Services;
using DevStore.Infra.Services;
using DevStore.Infra.StoreContext.DataContexts;
using DevStore.Infra.StoreContext.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevStore.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
