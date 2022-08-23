using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Curso
    {
        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public string Objetives { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public enum LevelEnum { Básico, Intermedio, Avanzado }
    }
}
