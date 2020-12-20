using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RemoveFieldCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "74be85d8-b129-4756-8af5-b9831a49da87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "14146bd5-dc62-482f-b235-c48ca04bde26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ebd8ee75-d4ab-4528-a0c2-80a1d77bf11b", "AQAAAAEAACcQAAAAEH4/bSYGqApp4aOzwOKOqtoZ3ARvt1KAMa8NEdlIGc8f7e1AmY+Tj2IwFAJtLantfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b902469f-19d9-4d8e-a1e9-9c73f1f743c4", "AQAAAAEAACcQAAAAECW1cELtxcyC1qZFR2v96lpbTbCt3zIOZ0q55vjJO84U8WVfwQfk5+ezKL8bpnEqjw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e136faf9-83f8-416a-824c-9f09a6667641", "AQAAAAEAACcQAAAAEKBfzO9UW6jvCERZIp8aboEO1zgRLIRg7xjTBgmhaSl9e2euVBfx4lOP4/OI5M6Mnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a111fc5-0861-4b88-90d6-70b978a70271", "AQAAAAEAACcQAAAAEO663x1c/M9dKIZasJRZJTpnv+Wkklwx9pfW37R3R8NvmBh8lknU1irwJ0R55s5mOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "976bf986-182b-4f94-975b-08fd1c896630", "AQAAAAEAACcQAAAAEHECOEbttErBSovo+r2DoPYXFcVS0Mcru9dKiBnEm2jz5cQj1Ewj5cwQaDUX/Ib7tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ca0b4bf-ee60-48e6-b2e8-e19f9060794f", "AQAAAAEAACcQAAAAEJKUgS6Xzv1C+P2yYww4pK65J63ogMLzRhYEBb19pUjE9owpBgeaq1LD2OoS2HJqww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c7db258-0efe-4493-a5ec-fab85e22c719", "AQAAAAEAACcQAAAAEKbVALvGq3Z14Z8qXOUHPXA/kYGlrjIxRYFE8i9GC6sHE/Fu1bbZF8pW86hWCVEX3Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "312b6403-dbf1-4196-9bad-cca3c705a3be", "AQAAAAEAACcQAAAAEDSbyNJwgYsTc/IARu92jXTAMDqgoX0RIPgNyfsEHRi1CqTU8Y3X3fd6vAiCNdrDtA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "422734d6-94f3-4276-b56c-6e4af2174171", "AQAAAAEAACcQAAAAECk9XLOxGq7bHLka8UcXDgbsfTgytv5ne6c54SGbR28cjjLlujKHAheiMD9KbhKr7g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "6670efb0-848d-4ee8-912b-00e21c04732c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "dc5269b5-096e-4ce4-a737-2c8b35bec2fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89c6dc1a-2ffb-4b0c-8bdf-1fb30d29177a", "AQAAAAEAACcQAAAAEE76GuWWWkfJYOWnMgGFewiInstMr8uG9VmOczVtSImF9zPuDWH+4D+eT1SU7q/ucg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c28a6ec7-e045-44cf-8526-07d879c87be1", "AQAAAAEAACcQAAAAEFZ3uuYk9bpm+yH28HIrN6ZM22NkR47m3+vbYYJn/60CZLBJ9tlMw+2G6EZ1WkOGLQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53c82814-1cd7-4899-9704-f90997d584d5", "AQAAAAEAACcQAAAAEGs3X2LjO9FMl4COaeYwTYWsS6+7Kd+6xqfV9Phe1uCuYG8EaW/Y8R15rXBY5CB1kg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ec68275-c949-4c82-9e69-a8da9625a3c2", "AQAAAAEAACcQAAAAEB9DcnNNvdoVLx7qFV1qUBSMoUhQjqohgHbVx6Xg58qY3lzJ8GvYwhGPa5dkE6VRAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2d355e2-0f59-4558-b661-18abe21745f3", "AQAAAAEAACcQAAAAENoXSlSYHIH7kp/qVCbSHlTPGYiFowH5EJt8iVcWU5K47X2Zm8ofMT7k2rcdsbH1aw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d11bb985-5542-4ef6-824b-1dcefab6eba9", "AQAAAAEAACcQAAAAEBdiWNArJmlEGstqSgGw7ncnnHxw0IYnzzGZ/8nI9COxCp4QiUo5wvEHgEwXcF8vaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "61808149-99d6-4991-820e-b3b50ef1f981", "AQAAAAEAACcQAAAAEJ+OXCaMlWO8opGHlUEpaLNxEbZx9Fg5hJMkwDKx0WLtYErruFpCbikxwDL+jgR4zw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b13f1df-a031-4ac9-867a-77bb894a33fc", "AQAAAAEAACcQAAAAECX6DU3VpPipYfvosw0ocg7FeXZ06MhOZA97hc1K77y4AMle4eOW95/csHYAxjTOLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5434ca52-ec1e-4809-8c2e-6118da13c03d", "AQAAAAEAACcQAAAAEG6jzIb4x2s7ZcLRbEX5ZqfMCvRw3zlYyKD+PWbcGqfZePIs15nc13t+XgtPyP4ObA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
