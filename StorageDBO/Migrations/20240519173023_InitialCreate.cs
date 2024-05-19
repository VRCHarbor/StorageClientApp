using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageDBO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticulGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articuls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticulSellerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticulName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticulImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticulGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articuls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articuls_ArticulGroups_ArticulGroupID",
                        column: x => x.ArticulGroupID,
                        principalTable: "ArticulGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticulId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InRecords_Articuls_ArticulId",
                        column: x => x.ArticulId,
                        principalTable: "Articuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InRecords_Incomes_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticulId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutRecords_Articuls_ArticulId",
                        column: x => x.ArticulId,
                        principalTable: "Articuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutRecords_Expenses_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articuls_ArticulGroupID",
                table: "Articuls",
                column: "ArticulGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_InRecords_ArticulId",
                table: "InRecords",
                column: "ArticulId");

            migrationBuilder.CreateIndex(
                name: "IX_InRecords_RecordId_ArticulId",
                table: "InRecords",
                columns: new[] { "RecordId", "ArticulId" });

            migrationBuilder.CreateIndex(
                name: "IX_OutRecords_ArticulId",
                table: "OutRecords",
                column: "ArticulId");

            migrationBuilder.CreateIndex(
                name: "IX_OutRecords_RecordId_ArticulId",
                table: "OutRecords",
                columns: new[] { "RecordId", "ArticulId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InRecords");

            migrationBuilder.DropTable(
                name: "OutRecords");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Articuls");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ArticulGroups");
        }
    }
}
