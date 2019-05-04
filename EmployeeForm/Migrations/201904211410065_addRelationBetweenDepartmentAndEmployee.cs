namespace EmployeeForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationBetweenDepartmentAndEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "Department_Id", c => c.Int());
            CreateIndex("dbo.Employee", "Department_Id");
            AddForeignKey("dbo.Employee", "Department_Id", "dbo.Department", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_Id", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_Id" });
            DropColumn("dbo.Employee", "Department_Id");
            DropColumn("dbo.Employee", "Fk_DepartmentId");
        }
    }
}
