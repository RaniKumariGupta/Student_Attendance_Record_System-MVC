using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_Record_SysteM.Migrations
{
    /// <inheritdoc />
    public partial class AddPresent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Student");
        }
    }
}
