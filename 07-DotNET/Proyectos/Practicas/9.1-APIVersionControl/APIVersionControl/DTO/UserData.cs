namespace APIVersionControl.DTO
{
    public class User // Este es el usuario que recibimos desde la Base de Datos Fake que nos genera usuarios Random. Que la usaremos para las pruebas. 
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? firstName { get; set; }   
        public string? lastName { get; set; }
        public string? picture { get; set; }

    }

    public class UsersResponseData // Datos que se van a enviar por respuesta, no tenemos que enviarlo todo. Enviaremos solo lo que queramos
    {
        public User[]? data { get; set; }   // Lista de usuarios
        public int total { get; set; }      // Total de usuarios
        public int page { get; set; }       // Pagina actual
        public int limit { get; set; }      // Limite de usuarios por pagina
    }
}
