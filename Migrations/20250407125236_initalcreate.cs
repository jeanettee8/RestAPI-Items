using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_Items.Migrations
{
    /// <inheritdoc />
    public partial class initalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemPrice = table.Column<double>(type: "REAL", nullable: true),
                    ItemCount = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemFabric = table.Column<char>(type: "TEXT", nullable: true),
                    ItemWillRestock = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
