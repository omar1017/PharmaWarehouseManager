﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkinanaPharma.Identity.Migrations
{
    /// <inheritdoc />
    public partial class some2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc44e46-a599-496b-aaab-5ca8f3214582", "AQAAAAIAAYagAAAAEACf+byrRwOAhsf93Tr1BDa7mUHkyxaycdILqZ9HSaZRGPASZYw4Ct4+cj0idS0i3Q==", "34d3641d-ce0d-4067-9065-dd14776a5bcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac589682-f729-4877-b985-a92cb90d760b", "AQAAAAIAAYagAAAAENjbclzuQbeaIXQkQrTePoZyqxSTv4V8utDE4OiZJRyLAqmlZ1tQ9VeFJXwgMR4r1Q==", "ce922714-c17b-4a95-8db6-a4cb90582e60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a1508f2-95ea-4496-ab0a-06291adc542f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf712616-1214-461e-807f-3bdd868b067b", "AQAAAAIAAYagAAAAEPBQyVwbaLSyh5LkqYlvLRnvS9uexjMPpTDtBKQlpYCBvI8aXY4v4VOFEYKSy/1p8A==", "2477e26f-809c-4ab5-847c-d6b1c665da47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2d89605-cf8a-4aaa-a1fc-4d454ea568ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "310d2d95-38e4-4792-8b5a-d7280f4f99f4", "AQAAAAIAAYagAAAAEAx78jV94hgU4ICckDt2nX788qSh/I63bZMRrjyRN+zqYotYMsH88NCAKFx+3dTmBA==", "de97831f-126c-4c3c-8443-5308591539cb" });
        }
    }
}
