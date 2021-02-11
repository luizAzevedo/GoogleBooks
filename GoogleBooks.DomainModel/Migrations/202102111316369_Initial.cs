namespace GoogleBooks.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbBook",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 200, unicode: false),
                        Title = c.String(nullable: false, maxLength: 2000, unicode: false),
                        Subtitle = c.String(nullable: false, maxLength: 2000, unicode: false),
                        Description = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        ChangeDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbBook");
        }
    }
}
