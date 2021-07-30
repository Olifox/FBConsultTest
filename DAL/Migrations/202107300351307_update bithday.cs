namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebithday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Bithday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Bithday", c => c.DateTime(nullable: false));
        }
    }
}
