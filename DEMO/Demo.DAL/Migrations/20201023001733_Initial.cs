using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZFramework.Demo.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    FullName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "FullName", "PasswordHash", "Username" },
                values: new object[] { 1, "Demo user", "WjESpjbNYSw4FzEGtE3cLzRaG9LVWcXz3e5UKFvbuZcSfLLCOkXw6UDvVUR2aoNKhaZtHOTU28wiIZ5wRvGh9w==", "demo" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ID", "PasswordHash" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
