using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserWithFastestTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FastestTimes",
                table: "FastestTimes");

            migrationBuilder.RenameTable(
                name: "FastestTimes",
                newName: "FastestTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FastestTime",
                table: "FastestTime",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FastestTime",
                table: "FastestTime");

            migrationBuilder.RenameTable(
                name: "FastestTime",
                newName: "FastestTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FastestTimes",
                table: "FastestTimes",
                column: "Id");
        }
    }
}
