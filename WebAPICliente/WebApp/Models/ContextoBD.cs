using System.Data.Entity;
using WebApp.Models.Domain;
using WebApp.Models.Mpas;

namespace WebApp.Models
{
    public class ContextoBD : DbContext
    {
        public ContextoBD() : base("name=StringConexao")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContextoBD>(null);
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        public DbSet<Cliente> Cliente { get; set; }

    }
}