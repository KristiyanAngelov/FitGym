using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitGym.Data.Migrations
{
    public partial class AddGroupTrainingDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupTrainingId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupTrainingId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupTrainingId",
                table: "AspNetUsers",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupTrainingId1",
                table: "AspNetUsers",
                column: "GroupTrainingId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroupTrainings_GroupTrainingId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupTrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupTrainingId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupTrainingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroupTrainingId1",
                table: "AspNetUsers");
        }
    }
}
