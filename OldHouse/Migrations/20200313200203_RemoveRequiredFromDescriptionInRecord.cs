using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class RemoveRequiredFromDescriptionInRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Records",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2147483647);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Records",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
