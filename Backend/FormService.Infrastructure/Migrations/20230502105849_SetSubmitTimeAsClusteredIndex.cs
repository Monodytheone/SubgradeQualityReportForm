using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetSubmitTimeAsClusteredIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_Forms_SubmitTime",
                table: "T_Forms",
                column: "SubmitTime")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_Forms_SubmitTime",
                table: "T_Forms");
        }
    }
}
