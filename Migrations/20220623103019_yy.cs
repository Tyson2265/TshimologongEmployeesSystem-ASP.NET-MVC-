using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App2.Migrations
{
    public partial class yy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "facilitator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrinterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    FacilitatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilitator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facilitator_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_facilitator_department_FacilitatorId",
                        column: x => x.FacilitatorId,
                        principalTable: "department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_facilitator_position_FacilitatorId",
                        column: x => x.FacilitatorId,
                        principalTable: "position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_facilitator_position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "intern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graduated = table.Column<bool>(type: "bit", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    isWorkIntegratedLearning = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    InternId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_intern_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_intern_department_InternId",
                        column: x => x.InternId,
                        principalTable: "department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_intern_position_InternId",
                        column: x => x.InternId,
                        principalTable: "position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_intern_position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facilitator_DepartmentId",
                table: "facilitator",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_facilitator_FacilitatorId",
                table: "facilitator",
                column: "FacilitatorId");

            migrationBuilder.CreateIndex(
                name: "IX_facilitator_PositionId",
                table: "facilitator",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_intern_DepartmentId",
                table: "intern",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_intern_InternId",
                table: "intern",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_intern_PositionId",
                table: "intern",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facilitator");

            migrationBuilder.DropTable(
                name: "intern");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "position");
        }
    }
}
