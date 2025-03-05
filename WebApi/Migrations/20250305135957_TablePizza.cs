using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class TablePizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SauceId",
                table: "Pizzas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceId",
                table: "Pizzas",
                column: "SauceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SauceId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SauceId",
                table: "Pizzas");
        }
    }
}
