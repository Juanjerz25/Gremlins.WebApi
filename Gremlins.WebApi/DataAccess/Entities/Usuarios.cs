using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gremlins.WebApi.DataAccess.Entities
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdRol { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
    }
}
