using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Machines_MachineId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MachineId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Patients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Machines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_PatientId",
                table: "Machines",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Patients_PatientId",
                table: "Machines",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Patients_PatientId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_PatientId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Machines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MachineId",
                table: "Patients",
                column: "MachineId");

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
