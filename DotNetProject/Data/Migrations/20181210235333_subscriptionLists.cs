using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetProject.Data.Migrations
{
    public partial class subscriptionLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APIListModel",
                table: "APIListModel");

            migrationBuilder.RenameTable(
                name: "APIListModel",
                newName: "APIListModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APIListModels",
                table: "APIListModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APIListModels",
                table: "APIListModels");

            migrationBuilder.RenameTable(
                name: "APIListModels",
                newName: "APIListModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APIListModel",
                table: "APIListModel",
                column: "Id");
        }
    }
}
