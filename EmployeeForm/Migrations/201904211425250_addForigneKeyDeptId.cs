namespace EmployeeForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForigneKeyDeptId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Department_Id", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_Id" });
            DropColumn("dbo.Employee", "Fk_DepartmentId");
            RenameColumn(table: "dbo.Employee", name: "Department_Id", newName: "Fk_DepartmentId");
            AlterColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "Fk_DepartmentId");
            AddForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Fk_DepartmentId" });
            AlterColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Employee", name: "Fk_DepartmentId", newName: "Department_Id");
            AddColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "Department_Id");
            AddForeignKey("dbo.Employee", "Department_Id", "dbo.Department", "Id");
        }
    }
}
