using Microsoft.Extensions.Configuration;
using Practica_Coches_AWS.Data;
using Practica_Coches_AWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_Coches_AWS.Repositories
{
    public class RepositoryCoches
    {
        CochesContext context;
        string urlBucket;

        public RepositoryCoches(CochesContext context, IConfiguration configuration)
        {
            this.context = context;
            this.urlBucket = configuration.GetValue<string>("AWS:UrlBucket");
        }

        public List<Coche> GetCoches()
        {
            List<Coche> coches = this.context.Coches.ToList();

            foreach(Coche c in coches)
            {
                c.Imagen = this.urlBucket + c.Imagen;
            }

            return coches;
        }

        public Coche FindCoche(int idcoche)
        {
            return this.context.Coches.SingleOrDefault(x => x.IdCoche == idcoche);
        }

        public void InsertarCoche(int id, string marca, string conductor, string imagen)
        {
            Coche c = new Coche
            {
                IdCoche = id,
                Marca = marca,
                Conductor = conductor,
                Imagen = imagen
            };

            this.context.Coches.Add(c);
            this.context.SaveChanges();
        }
    }
}
