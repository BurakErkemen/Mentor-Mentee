namespace multilayer_architecture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        department_id = c.Int(nullable: false, identity: true),
                        department_name = c.String(),
                        department_staffs = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.department_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_name = c.String(),
                        employee_lastname = c.String(),
                        employee_identity_card = c.Int(nullable: false),
                        department_department_id = c.Int(),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.Departments", t => t.department_department_id)
                .Index(t => t.department_department_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "department_department_id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "department_department_id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
