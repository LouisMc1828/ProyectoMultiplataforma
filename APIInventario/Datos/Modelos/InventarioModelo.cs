using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIInventario.Datos.Modelos
{
    [Table("Artículos")]
    public class InventarioModelo
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100), DataType(DataType.MultilineText), Display(Name = "Descripción Del Producto")]
        public string Descripcion_P { get; set; }

        [Required, Display(Name = "Cantidad Del Stock"), Range(0, 64)]
        public int Cantidad_S { get; set; }

        [Required, Display(Name = "Precio De Venta"), Range(1, 10000.00)]
        public float Precio_V { get; set; }

        [DataType(DataType.Date), Display(Name = "Fecha De Compra")]
        public DateTime? Fecha_C { get; set; }

        [DataType(DataType.Date), Display(Name = "Fecha De Expiración")]
        public DateTime? Fecha_E { get; set; }

    }
}
