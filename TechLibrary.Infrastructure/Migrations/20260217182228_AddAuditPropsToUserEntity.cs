using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditPropsToUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                table: "Users",
                name: "CreatedAt",
                type: "datetime(6)",
                nullable: false,
                defaultValue: DateTime.UtcNow
            );

            migrationBuilder.AddColumn<DateTime>(
                table: "Users",
                name: "UpdatedAt",
                type: "datetime(6)",
                nullable: true
            );

            migrationBuilder.AddColumn<DateTime>(
                table: "Users",
                name: "DeletedAt",
                type: "datetime(6)",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                table: "Users",
                name: "IsDeleted",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                table: "Users",
                name: "CreatedAt"
            );

            migrationBuilder.DropColumn(
                table: "Users",
                name: "UpdatedAt"
            );

            migrationBuilder.DropColumn(
                table: "Users",
                name: "DeletedAt"
            );

            migrationBuilder.DropColumn(
                table: "Users",
                name: "IsDeleted"
            );
        }
    }
}
