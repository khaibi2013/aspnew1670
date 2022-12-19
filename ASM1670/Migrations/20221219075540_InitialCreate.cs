using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM1670.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderPrice = table.Column<double>(type: "float", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "9422044e-50e7-4fe8-aae0-69f3479e0fd3", "Admin", "Admin" },
                    { "2", "5a25ecff-daab-42c4-b796-534a1d571a93", "Customer", "Customer" },
                    { "3", "d45169de-4639-4d30-ab69-ea3ae3f0c75b", "StoreOwner", "StoreOwner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "da9b7719-fead-4374-9041-0a5352283aca", "admin@gmail.com", false, false, null, null, "admin@gmail.com", "AQAAAAEAACcQAAAAECQa0AZ9YPPaLpFJ75lNkmgUTRd1sgBev2j6sXAanHkZTE7Ew9mXR06rmupeEm9Z2g==", null, false, "41305899-e874-4772-9777-aed831696779", false, "admin@gmail.com" },
                    { "2", 0, "16e5ca1c-e1a9-42f2-a771-49efd2b2cea3", "customer@gmail.com", false, false, null, null, "customer@gmail.com", "AQAAAAEAACcQAAAAENqnOPy8wTDfB5HgVdFWmXL/2qrRIGKwgudZlhSYpBdXBQkw9RwQfr+hwDUsFxLmwg==", null, false, "aee7a783-c502-4122-875e-20397fcbce5b", false, "customer@gmail.com" },
                    { "3", 0, "10674d52-fca5-48af-aa8e-97c2c885fb8f", "storeowner@gmail.com", false, false, null, null, "storeowner@gmail.com", "AQAAAAEAACcQAAAAEPx2+MQmJ9+H6SOoMNJV0HOSxVZwJ/lYJFRL28/kdabPS5TvMoAWpNgWVkwjsATKWA==", null, false, "054d6c6b-2a7c-4f5b-9c07-0464793112af", false, "storeowner@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Japan", "Gosho AOYAMA" },
                    { 2, "Japan", "Fujiko F Fujio" },
                    { 3, "Viet Nam", "Vu Trong Phung" },
                    { 4, "United States", "J. K. Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Comic" },
                    { 3, "Adventure" },
                    { 4, "Mystery" },
                    { 5, "Horror" },
                    { 6, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://tuoitho.mobi/upload/doc-truyen/conan/anh-dai-dien.jpg", 5.0, 30, "Conan" },
                    { 2, 2, 1, "https://tuoitho.mobi/upload/truyen/doremon-truyen-ngan-tap-3/anh-bia.jpg", 3.0, 30, "Doremon" },
                    { 3, 2, 3, "https://sach86.com/wp-content/uploads/2020/10/Lam-Di.jpg", 500.0, 30, "Làm ĐĨ" },
                    { 4, 3, 4, "https://cdn.vox-cdn.com/thumbor/dyjy2i3y73CS3m1uHvkgFMEJzqE=/1400x0/filters:no_upscale()/cdn.vox-cdn.com/uploads/chorus_asset/file/21960146/61JfGcL2ljL.jpg", 200.0, 30, "The Hunger Games" },
                    { 5, 4, 2, "http://prodimage.images-bn.com/pimages/9780545139700_p0_v5_s1200x630.jpg", 120.0, 30, "Harry Potter" },
                    { 6, 1, 3, "http://prodimage.images-bn.com/pimages/9780345806789_p0_v2_s1200x630.jpg", 120.0, 30, "The Shining" },
                    { 7, 4, 4, "https://salt.tikicdn.com/ts/product/17/22/0b/da2ced7d44ce084dd6b6dde1ce00b97a.jpg", 120.0, 30, "Cormoran Strike" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                table: "Order",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
