namespace Project.Models
{
    using DataModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class C1709M_PROJ : DbContext
    {
        
        public C1709M_PROJ()
            : base("name=C1709M_PROJ")
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<C1709M_PROJ, Migrations.Configuration>("C1709M_PROJ"));
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DataModels.Attribute> Attrbutes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttrs { get; set; }
        public virtual DbSet<TypeAttr> TypeAttrs { get; set; }
        public virtual DbSet<GroupRole> GroupRoles { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Bill> Billes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }

}