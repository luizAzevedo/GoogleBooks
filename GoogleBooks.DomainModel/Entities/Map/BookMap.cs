using System.Data.Entity.ModelConfiguration;

namespace GoogleBooks.DomainModel.Entities.Map
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("tbBook");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.Subtitle).HasColumnName(@"Subtitle").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(null);

            //BaseEntities
            Property(x => x.CreationDate).HasColumnName(@"CreationDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ChangeDate).HasColumnName(@"ChangeDate").HasColumnType("datetime").IsOptional();
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("bit").IsRequired();
        }
    }
}
