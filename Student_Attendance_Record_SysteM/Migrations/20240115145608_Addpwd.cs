using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_Record_SysteM.Migrations
{
    /// <inheritdoc />
    public partial class Addpwd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");
        }
    }
}
