using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddQuantityLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuantityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InStock = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce20f05-c625-43fc-ae25-a7514e9520db",
                column: "ConcurrencyStamp",
                value: "1bec178a-6d77-492b-954a-0db8750770a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b979036b-d165-4bea-b6b6-16b22a3f54dd",
                column: "ConcurrencyStamp",
                value: "14513bd3-bdad-43ab-9b33-b8a842241f3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "308da0db-e863-4814-8930-de3540e5406d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e62730a-f796-4818-a65a-757d0f849afa", "AQAAAAEAACcQAAAAEBtneNX+QFEQLpqhFZFSh/dzRjlU2LkmtbNraCZfeQv1sH7wz4L+gvcQ024Qt6i27A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39b465e2-c398-494f-bb62-d1eb02aa5471",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0b9f3f5-e63e-4dc6-bb0a-ace490a59233", "AQAAAAEAACcQAAAAEOrP/SOKZ1L08Hk2tKktwAb7+8FfB4RvxrTYSGfWgpAxRdfHqZnuudl8Yp85/NpD5A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b488e0f-eb92-4994-a555-cbe4ecdf3672",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6be168ed-2b47-4b0e-95be-48a81a7b9533", "AQAAAAEAACcQAAAAELZTX2Pg1JtetzE4chbdDyyr4Y5YL1LbfLbYRGwmEXjmxV5veOq1EQD9GWJMNLryXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52999f6b-a605-45b0-b98f-b8880fc46027",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9c0a3e6-cd91-4409-b22c-71fabdc1d818", "AQAAAAEAACcQAAAAEA72jBafJ+2wd4o8eZxWusbFaa8Rtrseng462T1Rr47SQxNCOWPs7z0/SrTPkMFKnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "927e4f6a-62ed-4e13-b002-7e133eb47bbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19e98eb4-b576-4cd9-9ebd-c9fa80cb89c9", "AQAAAAEAACcQAAAAEMLI/Q2mmMRBMxQUWrgCte2YDkOJxNMeRETdWpG943k+XuoAzYagb5I3Ua9QwI1/YQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51d48577-8889-4732-9e94-08283a61f4f3", "AQAAAAEAACcQAAAAECambQDhGNCRqr4SLJKwsr68ByuUOjq8qJleKlKrSsTA7Qv3E4Lwr5+nUjhV4z9rbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7610feb-110c-47d0-9a88-1bfdc12742a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c59e38b-df06-4c3a-a500-c1aa502d4b42", "AQAAAAEAACcQAAAAEDP6eQuFLAqCHH32dQ7/lnI1Uw+kWLGvxPy5sOoJ84fKFE0fCyBmrah1qdUVatpevA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dcdf4a7a-03b9-464a-b836-9aae2c929482", "AQAAAAEAACcQAAAAEKmrBsJEdhOYfiMAMtTZcWj1uHNn/KuIyxr+JecEawKQoZ+FxTm9zFPJurqPFHwkhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9a7449-e604-48c1-a638-c564e17c1bc0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46b039c7-6934-40d0-be78-15db331bd58c", "AQAAAAEAACcQAAAAEGjURWffJe+798qlYCgM1XnSZm922TmOixkVUd1yP4QbYnuv7WGFs9y7SLW5HKzq3A==" });

            migrationBuilder.CreateIndex(
                name: "IX_QuantityLogs_ProductId",
                table: "QuantityLogs",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityLogs");

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
        }
    }
}
