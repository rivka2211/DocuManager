using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocuManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class filehistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_ActivityHistories_ActivityHistoryId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ActivityHistoryId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ActivityHistoryId",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "ActivityHistoryFile",
                columns: table => new
                {
                    ActivityHistoriesId = table.Column<int>(type: "int", nullable: false),
                    FilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityHistoryFile", x => new { x.ActivityHistoriesId, x.FilesId });
                    table.ForeignKey(
                        name: "FK_ActivityHistoryFile_ActivityHistories_ActivityHistoriesId",
                        column: x => x.ActivityHistoriesId,
                        principalTable: "ActivityHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityHistoryFile_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityHistoryFile_FilesId",
                table: "ActivityHistoryFile",
                column: "FilesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityHistoryFile");

            migrationBuilder.AddColumn<int>(
                name: "ActivityHistoryId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ActivityHistoryId",
                table: "Files",
                column: "ActivityHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_ActivityHistories_ActivityHistoryId",
                table: "Files",
                column: "ActivityHistoryId",
                principalTable: "ActivityHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
