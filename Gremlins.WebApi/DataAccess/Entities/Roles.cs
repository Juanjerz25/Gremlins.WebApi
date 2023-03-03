using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DataAccess.Entities
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
