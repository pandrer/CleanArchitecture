using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.EntityFrameworkCore.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipAddres",
                table: "Orders",
                newName: "ShipAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipAddress",
                table: "Orders",
                newName: "ShipAddres");
        }
    }
}
