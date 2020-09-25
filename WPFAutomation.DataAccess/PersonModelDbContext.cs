using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WPFAutomation.Models;

namespace WPFAutomation.DataAccess
{
    public class PersonModelDbContext : DbContext
    {
        public PersonModelDbContext() :base("PersonModelDb")
        {

        }
        public DbSet<PersonModel> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
