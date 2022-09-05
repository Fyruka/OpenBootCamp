using System.Globalization;

namespace UniversityApiBackend.Models.DataModels
{
    public class UserTokens
    {
        public int Id { get; set; } // GUID es un tipo de datos binario de SQL Server de 16 bytes que es globalmente único en tablas, bases de datos y servidores. GLOBAL UNIQUE IDENTIFIER y es una implementación de Microsoft de un estándar llamado universally unique identifier (UUID)
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validity { get; set; } // Para que tenga validez durante N tiempo, ya sea horas o minutos. 
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DaylightTime ExpiredTime { get; set; }
    }
}
