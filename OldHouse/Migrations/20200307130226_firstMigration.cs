using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OldHouse.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Patient_PatientId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Relatives_RelativeId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_RelativeId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "BloodPressur",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "BloodSugarLevel",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "CholesterolLevel",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "HeartBeatPerSecond",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "SeenAt",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "RelativeId",
                table: "Patient");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Patients",
                newName: "Birthdate");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Relatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "Records",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Records",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BloodPressure",
                table: "Records",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GlucoseLevel",
                table: "Records",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HeartRate",
                table: "Records",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Alerts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "Alerts",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patients",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_PatientId",
                table: "Relatives",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Patients_PatientId",
                table: "Alerts",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patients_PatientId",
                table: "Records",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatives_Patients_PatientId",
                table: "Relatives",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Patients_PatientId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patients_PatientId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatives_Patients_PatientId",
                table: "Relatives");

            migrationBuilder.DropIndex(
                name: "IX_Relatives_PatientId",
                table: "Relatives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Relatives");

            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "GlucoseLevel",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "level",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Patient",
                newName: "Birthday");

            migrationBuilder.AlterColumn<int>(
                name: "Temperature",
                table: "Records",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Records",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "BloodPressur",
                table: "Records",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BloodSugarLevel",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CholesterolLevel",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Records",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HeartBeatPerSecond",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Alerts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Alerts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeenAt",
                table: "Alerts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Patient",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Patient",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Patient",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Patient",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelativeId",
                table: "Patient",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_RelativeId",
                table: "Patient",
                column: "RelativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Patient_PatientId",
                table: "Alerts",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Relatives_RelativeId",
                table: "Patient",
                column: "RelativeId",
                principalTable: "Relatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
