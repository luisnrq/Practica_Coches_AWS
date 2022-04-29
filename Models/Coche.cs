﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_Coches_AWS.Models
{
    [Table("coches")]
    public class Coche
    {
        [Key]
        [Column("idcoche")]
        public int IdCoche { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("conductor")]
        public string Conductor { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }
    }
}
