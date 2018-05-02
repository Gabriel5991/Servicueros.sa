using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class TipoBodega
    {
        public int TipoBodegaId { get; set; }

        [Display(Name = "Nombre")]
        public string Detalle { get; set; }
    }
}
