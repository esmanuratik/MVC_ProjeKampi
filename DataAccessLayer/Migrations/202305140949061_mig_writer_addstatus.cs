namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_addstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}
