using Microsoft.EntityFrameworkCore; // 1. Add usings to parent the class 
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext // 2. Parent the class with the using
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options) // 3. Create constructor for our class
        {

        }

        // TODO: Add DbSets (Table of Our DataBase)
        public DbSet<User>? Users { get; set; }
    }
}
