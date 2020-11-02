using Example.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Api.Data
{
    /// <summary>
    /// DbContext
    /// </summary>
    public class ExampleDbContext : DbContext
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="options">DB options</param>
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Utilisateurs
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
    }
}
