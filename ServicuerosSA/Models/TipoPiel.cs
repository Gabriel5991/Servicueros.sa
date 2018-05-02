using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class TipoPiel
    {
        public int TipoPielId { get; set; }

        [Display(Name = "Tipo de piel")]
        public string Detalle { get; set; }
    }
}
