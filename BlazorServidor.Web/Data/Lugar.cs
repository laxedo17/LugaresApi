using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServidor.Web.Data
{
    /// <summary>
    /// Misma clase que no proxecto da API
    /// excepto que decoramos algunhas
    /// propiedades con Required.
    /// Isto garantiza que estas propiedades
    /// non queden baleiras cando actualicemos
    /// o formulario.
    /// </summary>
    public class Lugar
    {
        public int Id { get; set; }
        [Required] public string Nome { get; set; }
        [Required] public string Localizacion { get; set; }
        [Required] public string Acerca { get; set; }
        public int Valoracions { get; set; }
        public string ImaxeDatos { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
