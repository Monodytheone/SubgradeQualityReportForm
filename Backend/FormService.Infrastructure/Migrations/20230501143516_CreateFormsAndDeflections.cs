using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateFormsAndDeflections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpresswayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractorCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupervisionCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubgradeType = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StakeNumberAndLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConstructionDate_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConstructionDate_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZeroFillingAndCutting_0_0dot80m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZeroFillingAndCutting_0_0dot80m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZeroFillingAndCutting_0_0dot80m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ZeroFillingAndCutting_0_0dot80m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightModerateAndHeavy_0_0dot80m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_0_0dot80m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_0_0dot80m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LightModerateAndHeavy_0_0dot80m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraAndExtremely_0_1dot20m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_0_1dot20m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_0_1dot20m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExtraAndExtremely_0_1dot20m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightModerateAndHeavy_0dot80_1dot50m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_0dot80_1dot50m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_0dot80_1dot50m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LightModerateAndHeavy_0dot80_1dot50m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraAndExtremely_1dot20_1dot90m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_1dot20_1dot90m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_1dot20_1dot90m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExtraAndExtremely_1dot20_1dot90m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightModerateAndHeavy_GreaterThan_1dot50m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_GreaterThan_1dot50m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LightModerateAndHeavy_GreaterThan_1dot50m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LightModerateAndHeavy_GreaterThan_1dot50m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraAndExtremely_GreaterThan_1dot90m__SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_GreaterThan_1dot90m__InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraAndExtremely_GreaterThan_1dot90m__Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExtraAndExtremely_GreaterThan_1dot90m__Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Forms", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "T_Deflections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceInForm = table.Column<int>(type: "int", nullable: false),
                    InspectionDetail_SpecifiedValueAndAllowableDeviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InspectionDetail_InspectionResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InspectionDetail_Code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InspectionDetail_Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Deflections", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_T_Deflections_T_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "T_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Deflections_FormId",
                table: "T_Deflections",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Deflections");

            migrationBuilder.DropTable(
                name: "T_Forms");
        }
    }
}
