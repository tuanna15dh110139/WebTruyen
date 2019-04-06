namespace WebTruyen.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Chuong");
            AlterColumn("dbo.Chuong", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Chuong", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Chuong");
            AlterColumn("dbo.Chuong", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Chuong", "ID");
        }
    }
}
