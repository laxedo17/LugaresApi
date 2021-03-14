using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LugaresApi.Db
{
    public static class LugarDbServiceExtension
    {
        /// <summary>
        /// Extension method que rexistra LugarDbContext como un servicio
        /// no contenedor DI (Dependency Injection)
        /// </summary>
        /// <param name="servicios"></param>
        /// <param name="nomeDb"></param>
        /// <typeparam name="LugarDbContext"></typeparam>
        public static void EngadeInMemoryDbService(this IServiceCollection servicios, string nomeDb) => servicios.AddDbContext<LugarDbContext>(options => options.UseInMemoryDatabase(nomeDb));

        /// <summary>
        /// Extension method responsable de xerar datos de test cando corre a aplicacion
        /// </summary>
        /// <param name="app"></param>
        public static void InicializarDatosSembrados(this IApplicationBuilder app)
        {
            using var scopeServicio = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var servicio = scopeServicio.ServiceProvider;
            LugarDbSeeder.Semilla(servicio);
        }
    }
}