using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class SesionUsuario
    {
        public int Id { get; set; }
        public int? IdSesion { get; set; }
        public string NombreUsuario { get; set; }
        public int? Team1Marcador { get; set; }
        public int? Team2Marcador { get; set; }

        public virtual Sesion IdSesionNavigation { get; set; }
    }
}
