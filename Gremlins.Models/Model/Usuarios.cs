using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
    }
}
