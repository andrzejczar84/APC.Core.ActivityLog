using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.Core.ActivityLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core_activitylog");

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                schema: "core_activitylog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DescriptionPrimary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DescriptionSecondary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EntityUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EntityDisplayPrimary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EntityDisplaySecondary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IconColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Granularity = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs",
                schema: "core_activitylog");
        }
    }
}
