using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class User: BaseEntity
    {
        [Required, StringLength(50)] // Este campo sera obligatorio y ademas lo limitamos a 50 caracteres.
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress] // Especificamos el tipo Email
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        //public ICollection<Id> Ids { get; set; } = new List<Id>();
    }
}
