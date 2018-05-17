using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Sexo
    {
        public int SexoId { get; set; }

        [Display(Name = "Seleccione su genero")]
        [Required(ErrorMessage ="Campo Requerido")]
        public string Detalle { get; set; }
       
       
    }
}
