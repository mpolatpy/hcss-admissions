using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActiveYear = table.Column<bool>(type: "INTEGER", nullable: false),
                    SchoolYearName = table.Column<string>(type: "TEXT", nullable: true),
                    FormLabel = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayOnForm = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotteries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotteries_Schools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "Schools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lotteries_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    LotteryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Zipcode = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryParentName = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryParentEmail = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryParentPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryParentRelationship = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryParentName = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryParentEmail = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryParentPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryParentRelationship = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentSchool = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentGrade = table.Column<string>(type: "TEXT", nullable: true),
                    HasSibling = table.Column<bool>(type: "INTEGER", nullable: false),
                    SiblingName = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    AgreeToTerms = table.Column<bool>(type: "INTEGER", nullable: false),
                    HowDidYouHear = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LotteryStatus = table.Column<string>(type: "TEXT", nullable: true),
                    WaitlistNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Lotteries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lotteries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_LotteryId",
                table: "Applications",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SchoolId",
                table: "Applications",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SchoolYearId",
                table: "Applications",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotteries_SchoolID",
                table: "Lotteries",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Lotteries_SchoolYearId",
                table: "Lotteries",
                column: "SchoolYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Lotteries");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "SchoolYears");
        }
    }
}
