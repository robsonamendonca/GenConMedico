﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenConMedico.Migrations
{
    public partial class EntidadeMonitoramentoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MedicamentosEmUso",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CirurgiasRealizadas",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alergias",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MonitoramentoPaciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PressaoArterial = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Temperatura = table.Column<decimal>(type: "DECIMAL(3,1)", nullable: false),
                    SaturacaoOxigenio = table.Column<byte>(type: "TINYINT", nullable: false),
                    FrequenciaCardiaca = table.Column<byte>(type: "TINYINT", nullable: false),
                    DataAfericao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoramentoPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonitoramentoPaciente_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonitoramentoPaciente_IdPaciente",
                table: "MonitoramentoPaciente",
                column: "IdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoramentoPaciente");

            migrationBuilder.AlterColumn<string>(
                name: "MedicamentosEmUso",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CirurgiasRealizadas",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alergias",
                table: "InformacoesComplementaresPaciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
