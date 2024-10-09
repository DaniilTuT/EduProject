using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewLessonConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "Lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "Lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "subject_name",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "teacher_name",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "type_of_lesson",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_date",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "subject_name",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "teacher_name",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "type_of_lesson",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lessons",
                newName: "Id");
        }
    }
}
