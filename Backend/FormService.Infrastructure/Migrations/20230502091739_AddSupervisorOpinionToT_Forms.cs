using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupervisorOpinionToT_Forms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupervisorOpinion_IsQualified",
                table: "T_Forms",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SupervisorOpinion_SupervisionDate",
                table: "T_Forms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SupervisorOpinion_SupervisorName",
                table: "T_Forms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorOpinion_UnqualifiedItems",
                table: "T_Forms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupervisorOpinion_IsQualified",
                table: "T_Forms");

            migrationBuilder.DropColumn(
                name: "SupervisorOpinion_SupervisionDate",
                table: "T_Forms");

            migrationBuilder.DropColumn(
                name: "SupervisorOpinion_SupervisorName",
                table: "T_Forms");

            migrationBuilder.DropColumn(
                name: "SupervisorOpinion_UnqualifiedItems",
                table: "T_Forms");
        }
    }
}
