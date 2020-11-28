using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitGym.Data.Migrations
{
    public partial class TrainingEntityChangesAndAddingExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.RenameColumn(
                name: "GroupTrainingId1",
                table: "AspNetUsers",
                newName: "TrainingId1");

            migrationBuilder.RenameColumn(
                name: "GroupTrainingId",
                table: "AspNetUsers",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GroupTrainingId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GroupTrainingId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TrainingId");

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrivateTraining = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IsDeleted",
                table: "Exercise",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TrainingId",
                table: "Exercise",
                column: "TrainingId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingId1",
                table: "AspNetUsers",
                newName: "GroupTrainingId1");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "AspNetUsers",
                newName: "GroupTrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TrainingId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GroupTrainingId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TrainingId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GroupTrainingId");

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_IsDeleted",
                table: "GroupTrainings",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId",
                table: "AspNetUsers",
                column: "GroupTrainingId",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId1",
                table: "AspNetUsers",
                column: "GroupTrainingId1",
                principalTable: "GroupTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
