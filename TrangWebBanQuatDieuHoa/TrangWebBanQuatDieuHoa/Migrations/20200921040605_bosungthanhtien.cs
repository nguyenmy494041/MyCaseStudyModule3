using Microsoft.EntityFrameworkCore.Migrations;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    public partial class bosungthanhtien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Thanhtien",
                table: "Order",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thanhtien",
                table: "Order");
        }
    }
}
