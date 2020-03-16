using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class AddSeenToAlert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Alerts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Alerts");
        }
    }
}
