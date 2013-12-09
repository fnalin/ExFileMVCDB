using ExFileMVCDB.Models.Mapping;
using System.Data.Entity;

namespace ExFileMVCDB.Models
{
    public class ExFileMVCDBContext : DbContext
    {
        static ExFileMVCDBContext()
        {
            Database.SetInitializer<ExFileMVCDBContext>(null);
        }

        public ExFileMVCDBContext()
            : base(@"Data Source=.\sqlexpress;Initial Catalog=ExFileMVCDB;Integrated Security=True;MultipleActiveResultSets=True")
        { }

        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArquivoMap());
        }
    }
}