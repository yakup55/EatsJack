using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityLayers.Concerete;
namespace DataAccesLayer.Conceret
{
    public class Context:DbContext
    {
        public Context() : base("Data Source=MSI;Initial Catalog=EatsJack;Integrated Security=True")
        {

        }
        public DbSet<About>Abouts { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet <Admin>Admins { get; set; }
        public DbSet <Chefs>Chefs { get; set; }
        public DbSet <ChefsMedia>ChefsMedias { get; set; }
        public DbSet <Comment>Comments { get; set; }
        public DbSet <Contact>Contacts { get; set; }
        public DbSet <Content>Contents { get; set; }
        public DbSet <Eats>Eats { get; set; }
        public DbSet <EatWriter>EatWriters { get; set; }
        public DbSet <ImageFile>ImageFiles { get; set; }
        public DbSet <Register>Registers { get; set; }
        public DbSet <Service>Services { get; set; }

    }
}
