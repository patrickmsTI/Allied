using Allied.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Allied.Data
{
    /// <summary>
    /// Class that implements the base context.
    /// </summary>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }


        /// <summary>
        /// Gets or sets the PhonePlan.
        /// </summary>
        /// <value>
        /// The bills.
        /// </value>
        public DbSet<PhonePlan> PhonePlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PhonePlan>(c =>
            {
                c.Property(e => e.PlanCode).ValueGeneratedOnAdd();

            });
        }

    }
}
