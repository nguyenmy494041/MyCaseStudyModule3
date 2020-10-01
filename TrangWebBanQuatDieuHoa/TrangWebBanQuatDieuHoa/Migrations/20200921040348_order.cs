using Microsoft.EntityFrameworkCore.Migrations;

namespace TrangWebBanQuatDieuHoa.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TinhThanh",
                columns: table => new
                {
                    TinhThanhId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanh = table.Column<string>(maxLength: 100, nullable: false),
                    TinhHayThanhPho = table.Column<string>(maxLength: 100, nullable: false),
                    MaBuuDien = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanh", x => x.TinhThanhId);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    QuanHuyenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(maxLength: 100, nullable: false),
                    QuanHayHuyen = table.Column<string>(maxLength: 100, nullable: false),
                    TinhThanhId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.QuanHuyenId);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanh_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanh",
                        principalColumn: "TinhThanhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuongXa",
                columns: table => new
                {
                    PhuongXaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhuongXa = table.Column<string>(maxLength: 100, nullable: false),
                    PhuongHayXa = table.Column<string>(maxLength: 30, nullable: false),
                    TinhThanhId = table.Column<int>(nullable: false),
                    QuanHuyenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongXa", x => x.PhuongXaId);
                    table.ForeignKey(
                        name: "FK_PhuongXa_QuanHuyen_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "QuanHuyenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<string>(maxLength: 100, nullable: false),
                    Adress = table.Column<string>(maxLength: 100, nullable: false),
                    TinhThanhId = table.Column<int>(nullable: false),
                    QuanHuyenId = table.Column<int>(nullable: false),
                    PhuongXaId = table.Column<int>(nullable: false),
                    Soluong = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_PhuongXa_PhuongXaId",
                        column: x => x.PhuongXaId,
                        principalTable: "PhuongXa",
                        principalColumn: "PhuongXaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PhuongXaId",
                table: "Order",
                column: "PhuongXaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhuongXa_QuanHuyenId",
                table: "PhuongXa",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_TinhThanhId",
                table: "QuanHuyen",
                column: "TinhThanhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PhuongXa");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "TinhThanh");
        }
    }
}
