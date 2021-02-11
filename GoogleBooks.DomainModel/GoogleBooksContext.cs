using GoogleBooks.DomainModel.Entities;
using GoogleBooks.DomainModel.Entities.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Diagnostics;

namespace GoogleBooks.DomainModel
{
    public class GoogleBooksContext : DbContext
    {
        static GoogleBooksContext()
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
            Database.SetInitializer<GoogleBooksContext>(null);
        }

        public GoogleBooksContext()
            : base("Name=GoogleBooksContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
#if DEBUG
            Database.Log = d => Debug.WriteLine(d);
#endif
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BookMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
