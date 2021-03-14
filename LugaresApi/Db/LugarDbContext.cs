using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LugaresApi.Db.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LugaresApi.Db
{
    public class LugarDbContext : DbContext
    {
        // Instancia DbContext
        public LugarDbContext(DbContextOptions<LugarDbContext> options) : base(options) { }

        // Entidade que expone unha propiedade Lugares (entidade) como unha
        // instancia de DbSet
        // DbSet<Lugar> representa unha coleccion de datos en memoria
        // e a porta de entrada para facer operacions de Bases de Datos 
        // calquer cambio en DbSet<Lugar> enviase a BD, tras invocar SaveChanges()
        public DbSet<Lugar> Lugares { get; set; }
    }
}
