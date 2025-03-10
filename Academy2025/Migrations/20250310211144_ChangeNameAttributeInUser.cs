using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy2025.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameAttributeInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUser_Courses_coursesId",
                table: "CourseUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser");

            migrationBuilder.DropIndex(
                name: "IX_CourseUser_coursesId",
                table: "CourseUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Users",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "coursesId",
                table: "CourseUser",
                newName: "CoursesId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser",
                columns: new[] { "CoursesId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UsersId",
                table: "CourseUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUser_Courses_CoursesId",
                table: "CourseUser",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUser_Courses_CoursesId",
                table: "CourseUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser");

            migrationBuilder.DropIndex(
                name: "IX_CourseUser_UsersId",
                table: "CourseUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Users",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseUser",
                newName: "coursesId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser",
                columns: new[] { "UsersId", "coursesId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_coursesId",
                table: "CourseUser",
                column: "coursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUser_Courses_coursesId",
                table: "CourseUser",
                column: "coursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
