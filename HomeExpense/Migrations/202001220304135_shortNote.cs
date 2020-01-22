namespace HomeExpense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shortNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "ShortNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "ShortNote");
        }
    }
}
