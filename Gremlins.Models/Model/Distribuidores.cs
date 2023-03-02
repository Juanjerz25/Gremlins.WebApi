using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class Distribuidores
    {
        public Distribuidores()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdDistribuidor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public decimal? NumeroTelefonico { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
