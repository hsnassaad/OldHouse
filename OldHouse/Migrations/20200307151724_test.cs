using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientId");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Battery = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MachineId",
                table: "Patients",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Machine_MachineId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MachineId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "MachineId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
