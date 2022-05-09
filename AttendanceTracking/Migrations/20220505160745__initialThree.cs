using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceTracking.Migrations
{
    public partial class _initialThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RfidId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "e75208bc-6f0f-493d-a28c-25c8a3563255");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65566ff6-6457-4041-8751-0c96d14d0916", "AQAAAAEAACcQAAAAEFf157Y+Z/ipRKuH2iQ0vayAjYzpc78sdIMQggUMVeYGdpz1o7/n+ytcMYgzGYl6Rw==" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("716c2e99-6f6c-4472-81a5-43c56e11637c"),
                column: "RfidId",
                value: " 99 62 36 BB ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RfidId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "d2506dc9-1b2b-48b5-9a25-e3f002deda32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8773b55-6737-4cfb-bd96-ef258c4d0e13", "AQAAAAEAACcQAAAAEISZodg0WEQHs01AVxNROekznzRoX5c/igsRADvuzvqTcgEVsXHJgnA+Qs4fRFrAOA==" });
        }
    }
}
