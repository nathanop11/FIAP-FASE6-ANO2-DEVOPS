using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Alunos.Migrations
{
    /// <inheritdoc />
    public partial class ModelingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraSeguranca",
                columns: table => new
                {
                    CameraId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VideoCamera = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataFilmagem = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSeguranca", x => x.CameraId);
                });

            migrationBuilder.CreateTable(
                name: "CentralSeguranca",
                columns: table => new
                {
                    CentralId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CameraId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LigarPolicia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LigarBombeiro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentralSeguranca", x => x.CentralId);
                    table.ForeignKey(
                        name: "FK_CentralSeguranca_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chamadas",
                columns: table => new
                {
                    LigacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataOcorrido = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NumeroLigacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CentralId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamadas", x => x.LigacaoId);
                });

            migrationBuilder.CreateTable(
                name: "SensorIncendio",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ComodoSensor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AlertaSensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorIncendio", x => x.SensorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentralSeguranca_UserId",
                table: "CentralSeguranca",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraSeguranca");

            migrationBuilder.DropTable(
                name: "CentralSeguranca");

            migrationBuilder.DropTable(
                name: "Chamadas");

            migrationBuilder.DropTable(
                name: "SensorIncendio");
        }
    }
}
