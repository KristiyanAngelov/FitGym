using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitGym.Data.Migrations
{
    public partial class AddWorkout_Exercise_User_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Execises_Workouts_WorkoutId",
                table: "Execises");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Execises_WorkoutId",
                table: "Execises");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkoutId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkoutId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Execises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "Workouts",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Workouts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientWorkouts",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWorkouts", x => new { x.ClientId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_ClientWorkouts_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerWorkouts",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerWorkouts", x => new { x.TrainerId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_TrainerWorkouts_AspNetUsers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercise",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercise", x => new { x.WorkoutId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_WorkoutExercise_Execises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Execises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutExercise_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientWorkouts_WorkoutId",
                table: "ClientWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerWorkouts_WorkoutId",
                table: "TrainerWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientWorkouts");

            migrationBuilder.DropTable(
                name: "TrainerWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Workouts",
                newName: "DateAndTime");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Execises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Execises_WorkoutId",
                table: "Execises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkoutId",
                table: "AspNetUsers",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkoutId1",
                table: "AspNetUsers",
                column: "WorkoutId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IsDeleted",
                table: "Appointment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TrainerId",
                table: "Appointment",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId",
                table: "AspNetUsers",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId1",
                table: "AspNetUsers",
                column: "WorkoutId1",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Execises_Workouts_WorkoutId",
                table: "Execises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
