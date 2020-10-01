using Microsoft.EntityFrameworkCore.Migrations;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    public partial class taolaibang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StateId",
                table: "Order",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_States_StateId",
                table: "Order",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_States_StateId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Order_StateId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
