using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.StoreContext.DataContext;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BaltaStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddResponseCompression(); // Adicionado Compressao nas respstas da Api

            // Injecao de depencia das classes o que os construtores dependem registrar aqui
            services.AddScoped<BaltaDataContext, BaltaDataContext>();// mantem uma instacia por escopo
            services.AddTransient<ICustomRepository, CustomerRepository>(); // instacia um novo uso descartou
            services.AddTransient<IEmailService, EmailService>();// instacia um novo uso descartou
            services.AddTransient<CustomerHandler, CustomerHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            //app.UseResponseCompression();// Adicionado Compressao nas respstas da Api usando o Gzip
            
        }
    }
}
