using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetProject.Data.Migrations
{
    public partial class subscriptionListsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubscriptionModels",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SubscriptionModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
