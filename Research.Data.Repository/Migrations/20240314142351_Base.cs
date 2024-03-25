using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Data.Repository.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Designation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Designation_ID);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Process_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Process_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Process_ID);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Report_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Report_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_ID = table.Column<int>(type: "int", nullable: false),
                    Status_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Report_ID);
                });

            migrationBuilder.CreateTable(
                name: "Security_Groups",
                columns: table => new
                {
                    Security_Group_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Security_Group_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Security_Group_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Groups", x => x.Security_Group_ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_AD_Flag = table.Column<bool>(type: "bit", nullable: false),
                    User_Reset_Password_Flag = table.Column<bool>(type: "bit", nullable: false),
                    Designation_ID = table.Column<int>(type: "int", nullable: false),
                    Designation_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Process_ID = table.Column<int>(type: "int", nullable: false),
                    Process_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_Designations_Designation_ID",
                        column: x => x.Designation_ID,
                        principalTable: "Designations",
                        principalColumn: "Designation_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Process_Process_ID",
                        column: x => x.Process_ID,
                        principalTable: "Process",
                        principalColumn: "Process_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feature_Permissions",
                columns: table => new
                {
                    Feature_Permission_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature_Permission_Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature_Permissions", x => x.Feature_Permission_ID);
                    table.ForeignKey(
                        name: "FK_Feature_Permissions_Status_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "Status",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Report_Map",
                columns: table => new
                {
                    User_Report_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_ID = table.Column<int>(type: "int", nullable: false),
                    Report_Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Report_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_ID = table.Column<int>(type: "int", nullable: false),
                    Status_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Report_Map", x => x.User_Report_ID);
                    table.ForeignKey(
                        name: "FK_User_Report_Map_Reports_Report_ID",
                        column: x => x.Report_ID,
                        principalTable: "Reports",
                        principalColumn: "Report_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Report_Map_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Security_Group_Map",
                columns: table => new
                {
                    User_Security_Group_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Security_Group_ID = table.Column<int>(type: "int", nullable: false),
                    Security_Group_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Security_Group_Map", x => x.User_Security_Group_ID);
                    table.ForeignKey(
                        name: "FK_User_Security_Group_Map_Security_Groups_Security_Group_ID",
                        column: x => x.Security_Group_ID,
                        principalTable: "Security_Groups",
                        principalColumn: "Security_Group_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Security_Group_Map_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security_Group_Feature_Permissions_Map",
                columns: table => new
                {
                    Security_Group_Feature_Permission_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Security_Group_ID = table.Column<int>(type: "int", nullable: false),
                    Security_Group_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_ID = table.Column<int>(type: "int", nullable: false),
                    Feature_Permission_Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Permission_Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Group_Feature_Permissions_Map", x => x.Security_Group_Feature_Permission_ID);
                    table.ForeignKey(
                        name: "FK_Security_Group_Feature_Permissions_Map_Feature_Permissions_Feature_Permission_ID",
                        column: x => x.Feature_Permission_ID,
                        principalTable: "Feature_Permissions",
                        principalColumn: "Feature_Permission_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_Group_Feature_Permissions_Map_Security_Groups_Security_Group_ID",
                        column: x => x.Security_Group_ID,
                        principalTable: "Security_Groups",
                        principalColumn: "Security_Group_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feature_Permissions_Status_ID",
                table: "Feature_Permissions",
                column: "Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Security_Group_Feature_Permissions_Map_Feature_Permission_ID",
                table: "Security_Group_Feature_Permissions_Map",
                column: "Feature_Permission_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Security_Group_Feature_Permissions_Map_Security_Group_ID",
                table: "Security_Group_Feature_Permissions_Map",
                column: "Security_Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Report_Map_Report_ID",
                table: "User_Report_Map",
                column: "Report_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Report_Map_User_ID",
                table: "User_Report_Map",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Security_Group_Map_Security_Group_ID",
                table: "User_Security_Group_Map",
                column: "Security_Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Security_Group_Map_User_ID",
                table: "User_Security_Group_Map",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Designation_ID",
                table: "Users",
                column: "Designation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Process_ID",
                table: "Users",
                column: "Process_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Security_Group_Feature_Permissions_Map");

            migrationBuilder.DropTable(
                name: "User_Report_Map");

            migrationBuilder.DropTable(
                name: "User_Security_Group_Map");

            migrationBuilder.DropTable(
                name: "Feature_Permissions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Security_Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Process");
        }
    }
}
