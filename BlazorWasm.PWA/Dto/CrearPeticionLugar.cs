using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.PWA.Dto
{
    public class CrearPeticionLugar
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Localizacion { get; set; }
        [Required]
        public string Acerca { get; set; }
        [Required]
        public int Valoracions { get; set; }
        public string ImaxeDatos { get; set; }
    }
}
