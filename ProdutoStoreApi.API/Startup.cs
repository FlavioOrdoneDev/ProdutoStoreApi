using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProdutoStoreApi.AplicacaoServico.AppServicos;
using ProdutoStoreApi.Dados.Contexto;
using ProdutoStoreApi.Dados.Repositorios;
using ProdutoStoreApi.Dominio.Repositorios;
using ProdutoStoreApi.Dominio.Servicos;
using ProdutoStoreApi.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.API
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
            services.AddControllers();

            services.AddDbContext<ProdutoStoreContexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));

            services.AddScoped<ProdutoStoreContexto>();

            services.AddTransient<ICategoriaAppServico, CategoriaAppServico>();
            services.AddTransient<IProdutoAppServico, ProdutoAppServico>();

            services.AddTransient<ICategoriaServico, CategoriaServico>();
            services.AddTransient<IProdutoServico, ProdutoServico>();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
