﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Infra.Data.Migrations
{
    public partial class TipoAlteradoNomeReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeReal",
                table: "IdentidadesSecretas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NomeReal",
                table: "IdentidadesSecretas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
