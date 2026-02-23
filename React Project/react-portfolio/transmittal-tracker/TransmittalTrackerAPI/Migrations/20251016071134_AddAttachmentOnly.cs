using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransmittalTrackerAPI.Migrations
{
    public partial class AddAttachmentOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Transmittals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Transmittals");
        }
    }
}