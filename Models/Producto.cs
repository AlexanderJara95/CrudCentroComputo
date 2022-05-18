using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAppCentroComputo.Models
{
    public partial class Producto
    {
        public string IdProd { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }

        [Column("Categoría")]
        public int? IdCateg { get; set; }

        [Column("Marca")]
        public int? IdMarca { get; set; }

        public virtual Categorium IdCategNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
    }
}
