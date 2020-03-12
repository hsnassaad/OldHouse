using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class AllowMachineIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Machines_MachineId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MachineId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MachineId",
                table: "Patients",
                column: "MachineId",
                unique: true,
                filter: "[MachineId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Machines_MachineId",
                table: "Patients",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Machines_MachineId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MachineId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MachineId",
                table: "Patients",
                column: "MachineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Machines_MachineId",
                table: "Patients",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
