namespace Gremlins.WebApi.DTO.Usuarios
{
    public class UsuariosDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdRol { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
    public class RequestLogin
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}
