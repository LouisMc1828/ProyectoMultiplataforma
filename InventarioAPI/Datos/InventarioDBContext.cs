using InventarioAPI.Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Datos
{
    public class InventarioDBContext : DbContext
    {
        public InventarioDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<InventarioModelo> Articulos { get; set; }
    }
}
