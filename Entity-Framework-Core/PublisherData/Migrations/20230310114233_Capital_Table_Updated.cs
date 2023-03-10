using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    public partial class Capital_Table_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapitalArea",
                table: "Capitals");

            migrationBuilder.AddColumn<string>(
                name: "CapitalCode",
                table: "Capitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 11,
                column: "CapitalCode",
                value: "DL");

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 12,
                column: "CapitalCode",
                value: "WSDC");

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 13,
                column: "CapitalCode",
                value: "MSC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapitalCode",
                table: "Capitals");

            migrationBuilder.AddColumn<int>(
                name: "CapitalArea",
                table: "Capitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 11,
                column: "CapitalArea",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 12,
                column: "CapitalArea",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Capitals",
                keyColumn: "CapitalId",
                keyValue: 13,
                column: "CapitalArea",
                value: 200);
        }
    }
}
