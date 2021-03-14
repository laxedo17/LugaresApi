using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LugaresApi.Db.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LugaresApi.Db
{
    public class LugarDbSeeder
    {
        private static string GetImaxe(string nomeArquivo, string tipoArquivo)
        {
            var ruta = Path.Combine(Environment.CurrentDirectory, "Db/Imaxes", nomeArquivo);
            // Obten arquivos de imaxes gardados dentro da carpeta Db/Imaxes
            var bytesImaxes = File.ReadAllBytes(ruta);
            // Convirte os bytes a un string en formato base64 e
            // devolve os datos formateados como unha imaxe
            return $"data:{tipoArquivo};base64,{Convert.ToBase64String(bytesImaxes)}";
        }

        /// <summary>
        /// Inicializa un par de conxuntos de datos de Semilla cando comenza a aplicacion
        /// engadindo os datos na entidade Lugares de LugarDbContext
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Semilla(IServiceProvider serviceProvider)
        {
            using var contexto = new LugarDbContext(serviceProvider.GetRequiredService<DbContextOptions<LugarDbContext>>());

            if (contexto.Lugares.Any()) { return; }
            contexto.Lugares.AddRange
            (
                new Lugar
                {
                    Id = 1,
                    Nome = "Illas Ons",
                    Localizacion = "Pontevedra, Galiza",
                    Acerca = "As illas Ons son un lugar indicado para turismo e para aquela xente que precise alonxarse da civilizacion e o ruido.",
                    Valoracions = 10,
                    ImaxeDatos = GetImaxe("illas_ons.jpg", "image/jpeg"),
                    UltimaActualizacion = DateTime.Now
                },
                new Lugar
                {
                    Id = 2,
                    Nome = "Oia",
                    Localizacion = "Pontevedra, Galiza",
                    Acerca = "Ver os montes da Groba tan preto e o mar ao lado e maravilloso",
                    Valoracions = 3,
                    ImaxeDatos = GetImaxe("oia.png", "image/png"),
                    UltimaActualizacion = DateTime.Now
                }
                );

            contexto.SaveChanges();
        }
    }
}
