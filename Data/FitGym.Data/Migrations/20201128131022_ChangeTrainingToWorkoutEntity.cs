using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitGym.Data.Migrations
{
    public partial class ChangeTrainingToWorkoutEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainings_TrainingId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "Exercise",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_TrainingId",
                table: "Exercise",
                newName: "IX_Exercise_WorkoutId");

            migrationBuilder.RenameColumn(
                name: "TrainingId1",
                table: "AspNetUsers",
                newName: "WorkoutId1");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "AspNetUsers",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TrainingId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_WorkoutId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TrainingId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_WorkoutId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrivateTraining = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_IsDeleted",
                table: "Workouts",
                column: "IsDeleted");

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
                name: "FK_Exercise_Workouts_WorkoutId",
                table: "Exercise",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workouts_WorkoutId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Workouts_WorkoutId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "Exercise",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                newName: "IX_Exercise_TrainingId");

            migrationBuilder.RenameColumn(
                name: "WorkoutId1",
                table: "AspNetUsers",
                newName: "TrainingId1");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "AspNetUsers",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_WorkoutId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_WorkoutId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TrainingId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateTraining = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IsDeleted",
                table: "Trainings",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId",
                table: "AspNetUsers",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId1",
                table: "AspNetUsers",
                column: "TrainingId1",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainings_TrainingId",
                table: "Exercise",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
