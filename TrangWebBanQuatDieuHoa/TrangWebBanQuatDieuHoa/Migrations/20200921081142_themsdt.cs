using Microsoft.EntityFrameworkCore.Migrations;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    public partial class themsdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "Order",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "Order");
        }
    }
}
