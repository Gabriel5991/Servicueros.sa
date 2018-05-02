using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Bodega1
    {
        public int Bodega1Id { get; set; }

        public int BodegaId { get; set; }
        public Bodega Bodegas { get; set; }

        public int LoteId { get; set; }
        public Lote Lotes { get; set; }
        public int ClasificacionId { get; set; }
        public Clasificacion Clasificaciones { get; set; }

        [Display(Name = "Fecha del ingreso de la piel a la bodega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fechaingreso { get; set; }

        [Display(Name = "Numero de estanteria")]
        public int NumeroEstanteria { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Ingrese el peso")]
        public int Peso { get; set; }

        [Display(Name = "Ingrese si existe alguna observacion en este proceso")]
        public String Observaciones { get; set; }
    }
}
