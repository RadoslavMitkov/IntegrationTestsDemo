using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegrationTestsDemo.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastNameAndMakeRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");
        }
    }
}
