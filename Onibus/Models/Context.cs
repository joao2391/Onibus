using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Onibus.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {

        public Context() : base("Onibus")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Carro> Onibus { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("usu_Usuario").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("usu_app_usuario").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("url_roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("uln_logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("ucm_claims");
            modelBuilder.Entity<IdentityRole>().ToTable("rls_roles");
        }

        public static Context Create()
        {
            return new Context();
        }


    }
}