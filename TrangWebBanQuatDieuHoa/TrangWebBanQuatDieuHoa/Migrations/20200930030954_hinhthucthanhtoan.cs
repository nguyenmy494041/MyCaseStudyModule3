using Microsoft.EntityFrameworkCore.Migrations;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    public partial class hinhthucthanhtoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Order",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Order");
        }
    }
}
