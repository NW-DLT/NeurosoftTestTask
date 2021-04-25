using Microsoft.EntityFrameworkCore.Migrations;

namespace OptionsListApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoreOptionType",
                columns: table => new
                {
                    MoreOptionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreOptionType", x => x.MoreOptionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "MoreOption",
                columns: table => new
                {
                    MoreOptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreOptionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreOption", x => x.MoreOptionID);
                    table.ForeignKey(
                        name: "FK_MoreOption_MoreOptionType_MoreOptionTypeID",
                        column: x => x.MoreOptionTypeID,
                        principalTable: "MoreOptionType",
                        principalColumn: "MoreOptionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ValueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoreOptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ValueID);
                    table.ForeignKey(
                        name: "FK_Values_MoreOption_MoreOptionID",
                        column: x => x.MoreOptionID,
                        principalTable: "MoreOption",
                        principalColumn: "MoreOptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoreOption_MoreOptionTypeID",
                table: "MoreOption",
                column: "MoreOptionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Values_MoreOptionID",
                table: "Values",
                column: "MoreOptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "MoreOption");

            migrationBuilder.DropTable(
                name: "MoreOptionType");
        }
    }
}
