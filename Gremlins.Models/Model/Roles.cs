using System;
using System.Collections.Generic;

#nullable disable

namespace Gremlins.Models.Model
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool? Habilitado { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
