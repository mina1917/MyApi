using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddParentIDToCategoryTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTags_Categories_CategoryID",
                table: "CategoryTags");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "CategoryTags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTags_ParentID",
                table: "CategoryTags",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTags_Categories_CategoryID",
                table: "CategoryTags",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTags_CategoryTags_ParentID",
                table: "CategoryTags",
                column: "ParentID",
                principalTable: "CategoryTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTags_Categories_CategoryID",
                table: "CategoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTags_CategoryTags_ParentID",
                table: "CategoryTags");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTags_ParentID",
                table: "CategoryTags");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "CategoryTags");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTags_Categories_CategoryID",
                table: "CategoryTags",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
