using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractMonthlyClaimSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClaimApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    NumofDays = table.Column<int>(type: "int", nullable: false),
                    ClaimTypeId = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimApplications_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimApplications_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimApplications_SystemCodesDetails_StatusId",
                        column: x => x.StatusId,
                        principalTable: "SystemCodesDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimApplications_ClaimTypeId",
                table: "ClaimApplications",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimApplications_LecturerId",
                table: "ClaimApplications",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimApplications_StatusId",
                table: "ClaimApplications",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimApplications");
        }
    }
}
