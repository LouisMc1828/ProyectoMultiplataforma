using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Carry_inventory_APP.repositorios
{
   public class RepositorioAPIInventario
    {
        public int Id { get; set; }

        public string Descripcion_P { get; set; }

        public int Cantidad_S { get; set; }

        public float Precio_V { get; set; }

        public DateTime? Fecha_C { get; set; }

        public DateTime? Fecha_E { get; set; }
    }
}
