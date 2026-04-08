using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorTemplates.Migrations.Ticket
{
    /// <inheritdoc />
    public partial class AddTicketSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketName",
                table: "Tickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "Tickets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "PointValue", "SprintNumber", "StatusId", "TicketDescription", "TicketName" },
                values: new object[,]
                {
                    { 1, 5, 1, "done", "Build Controllers for project", "Build Controllers" },
                    { 2, 10, 2, "todo", "Code all models for project", "Build Models" },
                    { 3, 8, 3, "todo", "Code Program.cs in project", "Complete Program.cs" },
                    { 4, 5, 3, "inprogress", "Make images folder and add images", "Images Folder" },
                    { 5, 10, 4, "qa", "Code unit tests for project", "Unit Testing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "TicketName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
