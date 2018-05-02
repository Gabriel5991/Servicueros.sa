using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ServicuerosSA.Models
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }

        [Required( ErrorMessage = "Campo Requrido") ]
        [Display(Name ="Numero de registro unico (RUC)")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El numero de caracteres debe ser 13 ")]
        public int Ruc { get; set; }
                
        [Required(ErrorMessage = "Campo Rrequerido")]
        [Display(Name = "Nombres del Proveedor ")]
        [StringLength(255, MinimumLength = 3 , ErrorMessage ="El numero de caracteres debe ser entre 3 y 255")]
        public string Nombres { get; set; }

        
        [Display(Name = "La direeccion del Proveedor ")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "El numero de caracteres debe ser entre 3 y 255")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo Rrequerido")]
        [Display(Name = "La direeccion del Proveedor ")]
        [StringLength(17, MinimumLength = 9, ErrorMessage = "El numero de caracteres debe ser entre 9 y 17")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo Rrequerido")]
        [Display(Name = "La direeccion del Proveedor ")]
        [StringLength(17, MinimumLength = 9, ErrorMessage = "El numero de caracteres debe ser entre 9 y 17")]
        public  string Celular { get; set; }

        [Display(Name = "El correo del Proveedor")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "El estado del Provedor esta activo  ")]
        [Required(ErrorMessage = "Campo Rrequerido")]
        public Boolean Estado { get; set; }

        [Display (Name = "Fecha de ingreso del Provedor ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fechaingreso { get; set; }




    }
}
