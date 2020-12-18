using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class SeedForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "7d2caabc-b153-495c-a18b-366e9b66b6bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "e479ae70-1a18-40db-a498-8c59e8bedef5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91f58d35-471e-4c24-99e5-619c578a79e6", "AQAAAAEAACcQAAAAELd3mT03VsE6nAur12K0RfLl/Ge81xaU2d+8kuhm7038nqSIxcciFgU7zoGKrL9Sxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3836bae-b053-4e95-b73a-bd0abe0f2b7e", "AQAAAAEAACcQAAAAECiP2TV6962DfJQiAENbnOSQ1QVRXapCAkSwz+kTMAifEdy/LzR8YkQdUgife5Ov2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04e8a076-20f8-494b-83d1-5495661094a2", "AQAAAAEAACcQAAAAEAuhSgz6FgxIL+qiIEMNawrEFkTN3OtHA2XOfadbMkmiXlPOdR4rEkh3Lz6XA5D6gQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "109877ce-ff4f-452c-9772-e151c7929b08", "AQAAAAEAACcQAAAAEPhdnlJBPygp/ECtnC2MUIsqR7d+f1DlG0hWCzniG0UC3DL7sprWfyaxeO6hg2KZNA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1be741b-b8fa-40e4-9e73-48e8d745b7e7", "AQAAAAEAACcQAAAAEPbLBafmBztrbQedf65KFycvtfkbiEN7GpEVufpuI0sQnj3B5QnQydIVDzjcmUGkxQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d27d0c48-a665-499a-a512-34bcf105806d", "AQAAAAEAACcQAAAAEPpIskNJ2c+u83v6ixQs/jkv9xycnloApgpHaH/4Pj7iL3CRRIuSC93K7expG3rHlg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b68a311-cb5a-478f-9edb-b6897603eb09", "AQAAAAEAACcQAAAAEK4S7Q4OIuDMO8yH36NehNo79jZLAL/KZKomTqB6sTVPIQZJkMvz8Hg/nfTr/K56MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0823bcc7-6afb-4228-98f0-ad0ce109d932", "AQAAAAEAACcQAAAAEKwAjg377ITdCqxD2XyUFEqTJPQlWTeY9MJjeto8pwzKQY2cX/R3mR2LcrGBKLxDYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6235a772-8644-4214-acf9-99a3ad596823", "AQAAAAEAACcQAAAAECPMixZ8F/nsfENmkBgU0JkspGEifg7SZu3GHXXoiehsYkt3XzsUWV55jq8KStbidg==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Linh Kiện PC" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PC Gaming" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ghế Gaming" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tai nghe" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chuột + Lót Chuột" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bàn Phím" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Màn Hình" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PC Văn Phòng" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "d32c06e8-cd9d-4835-a679-d93713f7f3e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "d0b7337e-45b8-4aad-9bfd-188d3d2a9c24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "304d46c4-4ba8-4a6d-95fa-db4cbb000af8", "AQAAAAEAACcQAAAAEK5tz+pcLrOJBJ2Zc7UV4R1b+paGFLWfBT6TdXQCdj+WR7yWjRfwmJFGeKq1/Bd7kg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "517521c5-a644-4952-89c5-713fc4c87ea7", "AQAAAAEAACcQAAAAEMjWPvmacktYZO7T6yvO4mbekzPTXr9EX3OMB2OZ9/ldEl3WFJlwyiI6qTtyI3eUjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "099b91c5-bc5a-4ab3-9d4c-2e1b3654426f", "AQAAAAEAACcQAAAAEEEd2DdwxqBV+9PTBSuRSSIX7fVnPJmjdfF8XHhmbA5ulbR4ukeb05IngPV/rgS++Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7679833a-c819-40dd-b57b-6a8e4888879e", "AQAAAAEAACcQAAAAECv5+0gFpv5WzRE2Ay/g+hf3X7BmUEg8rpDrFHETOuDrLKBz9vKXuXhe1B58TjSZ/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae11c82d-366a-4d3b-bf0e-2460190cdddc", "AQAAAAEAACcQAAAAEMDHue7/WLxjL7v0SntCKRPzKNPtMg0LFY1yIT/LWwQJbI9KjyjbtEm2767YPY7s1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28feea48-9d96-49bc-a5b8-046a20f979d1", "AQAAAAEAACcQAAAAEAAjiGQ6C/F0d3ZZD7QYY2cYAMLX6Od1UY1HLtic9GorstHV1vdCZnWgVkdc86gWRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88ee4cf0-4872-4b6a-b886-ca444a566b6a", "AQAAAAEAACcQAAAAEDcLfJYB1I3n6cPSn+BZQtq/4NWPKXJGUHzTmnYYSzTWyPKKSAi1rrTjihEa/DjMFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7485ac18-faeb-4f91-a509-45a6b4532513", "AQAAAAEAACcQAAAAEDHbth+JmPJdSTml+J2h/aUzVM+wtYasl8hKH2TMv/zPoxBY+/FzPrTEjyh7Wv3lbQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6dbb521d-e84c-4695-9a6f-fcf2fdd36a12", "AQAAAAEAACcQAAAAEAPl1ocXR5dUYvh8VOYVMRcv9WImkj7JVIqS9Ze3rOBzTn36mClt8thU0u86gjGr9g==" });
        }
    }
}
