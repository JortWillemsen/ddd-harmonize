using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleService.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampToEventsOnceMoreAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "events",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "events");
        }
    }
}
