using Store.Data.Configuration;
using Store.Model;
using System.Data.Entity;

namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities")
        {
            
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new GadgetConfiguration());
        }
    }
}
