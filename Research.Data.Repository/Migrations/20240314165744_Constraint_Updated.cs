using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Data.Repository.Migrations
{
    public partial class Constraint_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Created_By_ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Created_By_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status_ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status_Value",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Updated_By_ID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_Date",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Created_By_ID",
                table: "Security_Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Created_By_Name",
                table: "Security_Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "Security_Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status_ID",
                table: "Security_Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status_Value",
                table: "Security_Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Updated_By_ID",
                table: "Security_Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_By_Name",
                table: "Security_Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_Date",
                table: "Security_Groups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status_ID",
                table: "Users",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Security_Groups_Status_ID",
                table: "Security_Groups",
                column: "Status_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Groups_Status_Status_ID",
                table: "Security_Groups",
                column: "Status_ID",
                principalTable: "Status",
                principalColumn: "Status_ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Status_Status_ID",
                table: "Users",
                column: "Status_ID",
                principalTable: "Status",
                principalColumn: "Status_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Groups_Status_Status_ID",
                table: "Security_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Status_Status_ID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Status_ID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Security_Groups_Status_ID",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Created_By_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created_By_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status_Value",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Updated_By_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Updated_By_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Updated_Date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created_By_ID",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Created_By_Name",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Status_ID",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Status_Value",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Updated_By_ID",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Updated_By_Name",
                table: "Security_Groups");

            migrationBuilder.DropColumn(
                name: "Updated_Date",
                table: "Security_Groups");
        }
    }
}
