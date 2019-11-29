namespace WebSnack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "mgender", c => c.String());
            AddColumn("dbo.AspNetUsers", "mtel", c => c.String());
            AddColumn("dbo.AspNetUsers", "maddr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "maddr");
            DropColumn("dbo.AspNetUsers", "mtel");
            DropColumn("dbo.AspNetUsers", "mgender");
        }
    }
}
