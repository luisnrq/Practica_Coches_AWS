using Microsoft.EntityFrameworkCore;
using Practica_Coches_AWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_Coches_AWS.Data
{
    public class CochesContext: DbContext
    {
        public CochesContext(DbContextOptions<CochesContext> options) : base(options) { }

        public DbSet<Coche> Coches { get; set; }
    }
}
