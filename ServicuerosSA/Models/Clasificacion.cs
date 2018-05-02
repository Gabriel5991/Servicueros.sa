using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Clasificacion
    {
        public int ClasificacionId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Seleccione el tipo de piel")]
        public string Selecciones { get; set; }



       }
}
