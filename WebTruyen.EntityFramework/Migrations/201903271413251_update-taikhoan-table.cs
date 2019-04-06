namespace WebTruyen.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetaikhoantable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiKhoan", "NgaySinh", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaiKhoan", "NgaySinh");
        }
    }
}
