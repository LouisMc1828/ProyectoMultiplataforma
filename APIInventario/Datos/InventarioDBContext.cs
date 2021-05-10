using APIInventario.Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIInventario.Datos
{
    public class InventarioDBContext : DbContext
    {
        public InventarioDBContext(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<InventarioModelo> Productos { get; set; }
    }
}
