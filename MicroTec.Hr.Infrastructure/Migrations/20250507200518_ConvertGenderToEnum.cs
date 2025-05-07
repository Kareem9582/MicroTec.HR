using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroTec.Hr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConvertGenderToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Custodies",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Custodies",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);
        }
    }
}
