using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nature_Hub_Server.Migrations
{
    /// <inheritdoc />
    public partial class addingtablestodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NatureProducts",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProPrice = table.Column<double>(type: "float", nullable: false),
                    ProImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureProducts", x => x.ProId);
                });

            migrationBuilder.CreateTable(
                name: "Remedies",
                columns: table => new
                {
                    RemedyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedies", x => x.RemedyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NatureProducts");

            migrationBuilder.DropTable(
                name: "Remedies");
        }
    }
}
