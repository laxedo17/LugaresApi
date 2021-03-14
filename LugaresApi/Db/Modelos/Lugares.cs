using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LugaresApi.Db.Modelos
{
    public class Lugar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacion { get; set; }
        public string Acerca { get; set; }
        public int Valoracions { get; set; }
        public string ImaxeDatos { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
