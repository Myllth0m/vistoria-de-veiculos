using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao;
using VistoriaDeVeiculos.Services.ServicoDePainelDeControle;

namespace VistoriaDeVeiculos
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
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("VistoriaDeVeiculoDataBase")));
            services.AddScoped<CriarFormularioDeInspecao>();
            services.AddScoped<BuscarFormularioDeInspecao>();
            services.AddScoped<BuscarDadosDoPainelDeControle>();
            services.AddScoped<SalvarDadosDoFormulario>();
            services.AddScoped<SalvarPerguntasDoFormulario>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            RotativaConfiguration.Setup("");
        }
    }
}
