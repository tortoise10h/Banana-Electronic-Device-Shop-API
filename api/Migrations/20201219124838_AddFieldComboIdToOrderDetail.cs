using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddFieldComboIdToOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "OrderDetails",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "ef732901-ff5e-4e55-998e-9487dcab50d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "b883847b-027c-4256-b84f-f7022cbdca07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a81a817-f68b-498d-9abb-e66da37d614d", "AQAAAAEAACcQAAAAENPACgqbZLxJJt2fMh7Wo/nfwyChPVB8xIUCcIPnpruW1DI3z7CQ+NjfOQIj0FG0LA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e56d7b94-7e20-4333-8db2-1d91d054a1b2", "AQAAAAEAACcQAAAAEPShlRGkTnZIbuUcW3zNuJkti4Q+bKoIBwtG+yfmNkYs+e6m7uqpHfDQMC5n5a7IWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1fe19a0-6f57-42ff-8952-c08c123d6995", "AQAAAAEAACcQAAAAEOp7JOlxKFGzBP0aFfrLLMOSPe4m2fwRrN9w7neOBN7wPutp1sBVO/xQ0u2J2Uog0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26b18c63-2e1a-415f-a07f-4bff711e2de8", "AQAAAAEAACcQAAAAEDFp1Nd+Cdi8jexAhLeHV63LnP4wqGD0zPX/1LJxZPcIKQQOhiFQ1dmynJDavwjaOw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "294d732c-8e03-43d7-8703-b9fb1b777e1a", "AQAAAAEAACcQAAAAEPqbd54ZBv1YeY9/OYkGVmj7sDHOTwWPsaGzR+zjAuSxmW0EOfn/8p5o4bQDDF6HwA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "62a60b35-953b-4996-b916-1d9e6831c82f", "AQAAAAEAACcQAAAAECry14uH+w++d6OEhnbvP/UO/Jd4miJ2CND0+e+RGSIxaUREZKLE8Y024oN+D7cKiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e85379f-12e9-47af-89cc-8f56eca73ad8", "AQAAAAEAACcQAAAAEAdsvlYt1EtPaljgKS8FpSWwOw/1HARfHzUXFpgscyVoQUo1QGyVKMI6vJx9beWKpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba493690-af2a-4775-930f-812ce433438c", "AQAAAAEAACcQAAAAEDT6/nr99nTU9rDWgxEeBBLOOF+ZlpNwq48HYWJEdnKkdotvahCGS8XEIyTQ353Neg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c501e871-f26f-4b91-aa6e-2095edaef106", "AQAAAAEAACcQAAAAEEiMaoCaHWpemikMZMepnW/DtNkW60keVym5vNW5P5nb4wVSNw9uGlZtbo8VxkvhZg==" });
        }
    }
}
