using Microsoft.EntityFrameworkCore; // 1. Add usings to parent the class 
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext // 2. Parent the class with the using
    {
        // 1. En el contructor inicializar una factoria de logs
        private readonly ILoggerFactory _loggerFactory;
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options) // 3. Create constructor for our class
        {
            _loggerFactory = loggerFactory;
        }

        // TODO: Add DbSets (Table of Our DataBase)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            // optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name })); // Le estamos diciendo que guarde los logs de nivel INFORMATION en nuestra base de datos
            // optionsBuilder.EnableSensitiveDataLogging(); // Habilita que guardemos todos los parametros, incluida informacion sensible como passwords, etc.

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

    }
}
