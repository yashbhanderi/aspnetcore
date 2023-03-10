using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    public partial class Country_Capital_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Capitals",
                columns: table => new
                {
                    CapitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapitalArea = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitals", x => x.CapitalId);
                    table.ForeignKey(
                        name: "FK_Capitals_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[] { 1, "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[] { 2, "US", "USA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[] { 3, "RSA", "Russia" });

            migrationBuilder.InsertData(
                table: "Capitals",
                columns: new[] { "CapitalId", "CapitalArea", "CapitalName", "CountryId" },
                values: new object[] { 11, 200, "Delhi", 1 });

            migrationBuilder.InsertData(
                table: "Capitals",
                columns: new[] { "CapitalId", "CapitalArea", "CapitalName", "CountryId" },
                values: new object[] { 12, 200, "Washington D.C.", 2 });

            migrationBuilder.InsertData(
                table: "Capitals",
                columns: new[] { "CapitalId", "CapitalArea", "CapitalName", "CountryId" },
                values: new object[] { 13, 200, "Moscow", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Capitals_CountryId",
                table: "Capitals",
                column: "CountryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capitals");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
