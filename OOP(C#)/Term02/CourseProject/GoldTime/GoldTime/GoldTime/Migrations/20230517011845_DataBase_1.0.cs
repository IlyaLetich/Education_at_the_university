using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldTime.Migrations
{
    /// <inheritdoc />
    public partial class DataBase_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketWatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketWatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComparisonWatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparisonWatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameNews = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationsNews = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuentityWatchOrder = table.Column<int>(type: "int", nullable: false),
                    PriceOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentOrders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    OrdersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentOrders", x => new { x.OrdersId, x.OrdersUserId });
                    table.ForeignKey(
                        name: "FK_EnrollmentOrders_OrdersUser_OrdersUserId",
                        column: x => x.OrdersUserId,
                        principalTable: "OrdersUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WatchesBasketId = table.Column<int>(type: "int", nullable: false),
                    ComparisonWatchesId = table.Column<int>(type: "int", nullable: false),
                    OrdersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BasketWatches_WatchesBasketId",
                        column: x => x.WatchesBasketId,
                        principalTable: "BasketWatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_ComparisonWatches_ComparisonWatchesId",
                        column: x => x.ComparisonWatchesId,
                        principalTable: "ComparisonWatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_OrdersUser_OrdersUserId",
                        column: x => x.OrdersUserId,
                        principalTable: "OrdersUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentBasket",
                columns: table => new
                {
                    BasketWatchesId = table.Column<int>(type: "int", nullable: false),
                    WatchesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentBasket", x => new { x.BasketWatchesId, x.WatchesId });
                    table.ForeignKey(
                        name: "FK_EnrollmentBasket_BasketWatches_BasketWatchesId",
                        column: x => x.BasketWatchesId,
                        principalTable: "BasketWatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentBasket_Watches_WatchesId",
                        column: x => x.WatchesId,
                        principalTable: "Watches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentComparison",
                columns: table => new
                {
                    ComparisonWatchesId = table.Column<int>(type: "int", nullable: false),
                    WatchesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentComparison", x => new { x.ComparisonWatchesId, x.WatchesId });
                    table.ForeignKey(
                        name: "FK_EnrollmentComparison_ComparisonWatches_ComparisonWatchesId",
                        column: x => x.ComparisonWatchesId,
                        principalTable: "ComparisonWatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentComparison_Watches_WatchesId",
                        column: x => x.WatchesId,
                        principalTable: "Watches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBasket_WatchesId",
                table: "EnrollmentBasket",
                column: "WatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentComparison_WatchesId",
                table: "EnrollmentComparison",
                column: "WatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentOrders_OrdersUserId",
                table: "EnrollmentOrders",
                column: "OrdersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ComparisonWatchesId",
                table: "Users",
                column: "ComparisonWatchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrdersUserId",
                table: "Users",
                column: "OrdersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WatchesBasketId",
                table: "Users",
                column: "WatchesBasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentBasket");

            migrationBuilder.DropTable(
                name: "EnrollmentComparison");

            migrationBuilder.DropTable(
                name: "EnrollmentOrders");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BasketWatches");

            migrationBuilder.DropTable(
                name: "ComparisonWatches");

            migrationBuilder.DropTable(
                name: "OrdersUser");
        }
    }
}
