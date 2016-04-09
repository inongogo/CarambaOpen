using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CarambaOpen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarRentalCost = table.Column<int>(nullable: false),
                    Cons = table.Column<string>(nullable: true),
                    DestinationCity = table.Column<string>(nullable: true),
                    DestinationCountry = table.Column<string>(nullable: true),
                    FoodDrinkCost = table.Column<int>(nullable: false),
                    GolfClub1Name = table.Column<string>(nullable: true),
                    GolfClub1Url = table.Column<string>(nullable: true),
                    GolfClub2Name = table.Column<string>(nullable: true),
                    GolfClub2Url = table.Column<string>(nullable: true),
                    GolfClub3Name = table.Column<string>(nullable: true),
                    GolfClub3Url = table.Column<string>(nullable: true),
                    GolfCost = table.Column<int>(nullable: false),
                    HotellName = table.Column<string>(nullable: true),
                    HotellUrl = table.Column<string>(nullable: true),
                    LivingCost = table.Column<int>(nullable: false),
                    LivingType = table.Column<string>(nullable: true),
                    Pros = table.Column<string>(nullable: true),
                    TravelCost = table.Column<int>(nullable: false),
                    TravelType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alt1 = table.Column<string>(nullable: true),
                    Alt2 = table.Column<string>(nullable: true),
                    Alt3 = table.Column<string>(nullable: true),
                    Alt4 = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Quest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poll_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alt1 = table.Column<string>(nullable: false),
                    Alt2 = table.Column<string>(nullable: false),
                    Alt3 = table.Column<string>(nullable: false),
                    Alt4 = table.Column<string>(nullable: false),
                    PollId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Answer");
            migrationBuilder.DropTable("Destination");
            migrationBuilder.DropTable("Poll");
            migrationBuilder.DropTable("Question");
            migrationBuilder.DropTable("User");
        }
    }
}
