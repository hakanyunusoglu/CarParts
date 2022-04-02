using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParts.Persistence.Migrations
{
    public partial class oguzMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "SellerLists",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerLists_ProductId1",
                table: "SellerLists",
                column: "ProductId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerLists_Products_ProductId1",
                table: "SellerLists",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerLists_Products_ProductId1",
                table: "SellerLists");

            migrationBuilder.DropIndex(
                name: "IX_SellerLists_ProductId1",
                table: "SellerLists");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "SellerLists");
        }
    }
}
