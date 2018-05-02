using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicuerosSA.Models
{
    public class Lote
    {
        public int LoteId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name ="El Codigo de lote")]
        public string Codigolote { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [Display(Name ="Numero de pieles")]
        public int Numerodepieles { get; set; }

        [Display(Name = "Fecha de ingreso de pieles ")]
        [Required(ErrorMessage ="La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fechaingreso { get; set; }
         
        [Display(Name = " El nombre responsable en recibir el lote ")]
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }

        public int TipoPielId { get; set; }
        public TipoPiel TipoPieles { get; set; }

        [Display(Name = "Si existe alguna observacion en la piel ingresada")]
        public String Observaciones { get; set; }

    }
}
