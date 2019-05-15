using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickCuts.Data.Migrations
{
    public partial class servicesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Barber_BarberId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "Services",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Services",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BarberId",
                table: "Services",
                column: "BarberId",
                unique: true,
                filter: "[BarberId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Barber_BarberId",
                table: "Services",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Barber_BarberId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BarberId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "Services",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Barber_BarberId",
                table: "Services",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
