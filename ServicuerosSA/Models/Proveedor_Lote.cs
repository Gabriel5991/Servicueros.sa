using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models
{
    public class Proveedor_Lote
    {
        public int Proveedor_LoteId { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedores { get; set; }
        public int LoteId { get; set; }
        public Lote Lotes { get; set; }
    }
}
