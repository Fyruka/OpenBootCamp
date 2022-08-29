using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]  // Especificamos que el campo es obligatorio
        [Key]       // Que es una Key, para que este relacionado con otras tablas
        public int Id { get; set; } // Creamos el campo en este caso de ID
        public string CreatedBy { get; set; } = string.Empty; // Creamos un segundo campo, en este caso no es required, ni tampoco una Key, porque no se lo hemos especificado.
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; } // Al crearlo colocamos el ? para definir que si que podria ser NULL o estar vacio. Ya que por defecto campos string o de otros tipos pueden no aceptar null
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
