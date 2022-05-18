using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppCentroComputo.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCateg { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
