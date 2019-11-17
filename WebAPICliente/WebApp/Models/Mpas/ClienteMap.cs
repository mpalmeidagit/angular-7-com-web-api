using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApp.Models.Domain;

namespace WebApp.Models.Mpas
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {

        public ClienteMap()
        {
            ToTable("tab_clientes");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            Property(x => x.Endereco).HasColumnName("endereco").HasMaxLength(100).IsRequired();
            Property(x => x.Telefone).HasColumnName("telefone").HasMaxLength(15).IsRequired();
            Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            Property(x => x.Cidade).HasColumnName("cidade").HasMaxLength(100).IsRequired();
        }
    }
}