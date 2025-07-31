using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BourbonWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sample",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PaymentDate",
                table: "Sample",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Sample",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "TargetYM",
                table: "Sample",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "Sample",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "Sample",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                table: "Sample",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                table: "Sample",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                table: "Sample",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sample",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Sample",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "TargetYM",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Text1",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Text2",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Text3",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Text4",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Text5",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Sample");
        }
    }
}
