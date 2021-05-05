using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaAcademyDatabseOnCSharp.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    city = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    postcode = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__23BEBA6BFBCF12A4", x => x.city);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    stream = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    years_run = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Streams__3F189F46E89B1DF3", x => x.stream);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    trainer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    last_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    years_of_experience = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.trainer_id);
                    table.ForeignKey(
                        name: "FK__Trainers__locati__607251E5",
                        column: x => x.location,
                        principalTable: "Locations",
                        principalColumn: "city",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    stream = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__1241F7F709AF292B", x => x.course);
                    table.ForeignKey(
                        name: "FK__Courses__stream__5D95E53A",
                        column: x => x.stream,
                        principalTable: "Streams",
                        principalColumn: "stream",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainersStreamsLink",
                columns: table => new
                {
                    trainer_id = table.Column<int>(type: "int", nullable: true),
                    stream = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__TrainersS__strea__690797E6",
                        column: x => x.stream,
                        principalTable: "Streams",
                        principalColumn: "stream",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TrainersS__train__681373AD",
                        column: x => x.trainer_id,
                        principalTable: "Trainers",
                        principalColumn: "trainer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    trainee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    last_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    trainer_id = table.Column<int>(type: "int", nullable: true),
                    stream = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    course = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    location = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.trainee_id);
                    table.ForeignKey(
                        name: "FK__Trainees__course__65370702",
                        column: x => x.course,
                        principalTable: "Courses",
                        principalColumn: "course",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Trainees__locati__662B2B3B",
                        column: x => x.location,
                        principalTable: "Locations",
                        principalColumn: "city",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Trainees__stream__6442E2C9",
                        column: x => x.stream,
                        principalTable: "Streams",
                        principalColumn: "stream",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Trainees__traine__634EBE90",
                        column: x => x.trainer_id,
                        principalTable: "Trainers",
                        principalColumn: "trainer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainersCoursesLink",
                columns: table => new
                {
                    trainer_id = table.Column<int>(type: "int", nullable: false),
                    course = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__TrainersC__cours__6BE40491",
                        column: x => x.course,
                        principalTable: "Courses",
                        principalColumn: "course",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TrainersC__train__6AEFE058",
                        column: x => x.trainer_id,
                        principalTable: "Trainers",
                        principalColumn: "trainer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_stream",
                table: "Courses",
                column: "stream");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_course",
                table: "Trainees",
                column: "course");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_location",
                table: "Trainees",
                column: "location");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_stream",
                table: "Trainees",
                column: "stream");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_trainer_id",
                table: "Trainees",
                column: "trainer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_location",
                table: "Trainers",
                column: "location");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersCoursesLink_course",
                table: "TrainersCoursesLink",
                column: "course");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersCoursesLink_trainer_id",
                table: "TrainersCoursesLink",
                column: "trainer_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersStreamsLink_stream",
                table: "TrainersStreamsLink",
                column: "stream");

            migrationBuilder.CreateIndex(
                name: "IX_TrainersStreamsLink_trainer_id",
                table: "TrainersStreamsLink",
                column: "trainer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "TrainersCoursesLink");

            migrationBuilder.DropTable(
                name: "TrainersStreamsLink");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
