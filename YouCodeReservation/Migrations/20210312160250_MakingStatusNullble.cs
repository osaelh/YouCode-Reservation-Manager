using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouCodeReservation.Migrations
{
    public partial class MakingStatusNullble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reservations",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.CreateTable(
                name: "ReservationViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    RequestingStudentId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ReservationTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationViewModel_AspNetUsers_RequestingStudentId",
                        column: x => x.RequestingStudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationViewModel_ReservationTypes_ReservationTypeId",
                        column: x => x.ReservationTypeId,
                        principalTable: "ReservationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationViewModel_RequestingStudentId",
                table: "ReservationViewModel",
                column: "RequestingStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationViewModel_ReservationTypeId",
                table: "ReservationViewModel",
                column: "ReservationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationViewModel");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reservations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }
    }
}
