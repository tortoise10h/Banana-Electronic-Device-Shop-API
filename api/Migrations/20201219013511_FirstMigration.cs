using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DiscountPercent = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PriceForSale = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivingNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivingNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DeliveryAddress = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsDeliveryNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDeliveryNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsDeliveryNotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsDeliveryNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComboDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    GoodsReceivingNoteId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingDetails_GoodsReceivingNotes_GoodsReceivingNoteId",
                        column: x => x.GoodsReceivingNoteId,
                        principalTable: "GoodsReceivingNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceivingDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "GoodsDeliveryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    GoodsDeliveryNoteId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDeliveryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsDeliveryDetails_GoodsDeliveryNotes_GoodsDeliveryNoteId",
                        column: x => x.GoodsDeliveryNoteId,
                        principalTable: "GoodsDeliveryNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsDeliveryDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b979036b-d165-4bea-b6b6-16b22a3f54dd", "b883847b-027c-4256-b84f-f7022cbdca07", "Admin", "admin" },
                    { "5ce20f05-c625-43fc-ae25-a7514e9520db", "ef732901-ff5e-4e55-998e-9487dcab50d5", "Customer", "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "fd9a7449-e604-48c1-a638-c564e17c1bc0", 0, "c501e871-f26f-4b91-aa6e-2095edaef106", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongtuantu@gmail.com", true, "Tú", "Trương Tuấn", false, null, "TRUONGTUANTU@GMAIL.COM", "TRUONGTUANTU@GMAIL.COM", "AQAAAAEAACcQAAAAEEiMaoCaHWpemikMZMepnW/DtNkW60keVym5vNW5P5nb4wVSNw9uGlZtbo8VxkvhZg==", "0901234578", false, "", false, "truongtuantu@gmail.com" },
                    { "39b465e2-c398-494f-bb62-d1eb02aa5471", 0, "e56d7b94-7e20-4333-8db2-1d91d054a1b2", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "s2nak@gmail.com", true, "Khoa", "Nguyen Anh", false, null, "S2NAK@GMAIL.COM", "S2NAK@GMAIL.COM", "AQAAAAEAACcQAAAAEPShlRGkTnZIbuUcW3zNuJkti4Q+bKoIBwtG+yfmNkYs+e6m7uqpHfDQMC5n5a7IWw==", "0901234572", false, "", false, "s2nak@gmail.com" },
                    { "52999f6b-a605-45b0-b98f-b8880fc46027", 0, "26b18c63-2e1a-415f-a07f-4bff711e2de8", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "luubaominh@gmail.com", true, "Minh", "Luu Bao", false, null, "LUUBAOMINH@GMAIL.COM", "LUUBAOMINH@GMAIL.COM", "AQAAAAEAACcQAAAAEDFp1Nd+Cdi8jexAhLeHV63LnP4wqGD0zPX/1LJxZPcIKQQOhiFQ1dmynJDavwjaOw==", "0901234564", false, "", false, "luubaominh@gmail.com" },
                    { "3b488e0f-eb92-4994-a555-cbe4ecdf3672", 0, "e1fe19a0-6f57-42ff-8952-c08c123d6995", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ngtanhu99@gmail.com", true, "Huy", "Nguyen Tan", false, null, "NGTANHU99@GMAIL.COM", "NGTANHU99@GMAIL.COM", "AQAAAAEAACcQAAAAEOp7JOlxKFGzBP0aFfrLLMOSPe4m2fwRrN9w7neOBN7wPutp1sBVO/xQ0u2J2Uog0w==", "0764928878", false, "", false, "ngtanhu99@gmail.com" },
                    { "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16", 0, "62a60b35-953b-4996-b916-1d9e6831c82f", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "luongtulinh@gmail.com", true, "Linh", "Luong Tu", false, null, "LUONGTULINH@GMAIL.COM", "LUONGTULINH@GMAIL.COM", "AQAAAAEAACcQAAAAECry14uH+w++d6OEhnbvP/UO/Jd4miJ2CND0+e+RGSIxaUREZKLE8Y024oN+D7cKiQ==", "0901234561", false, "", false, "luongtulinh@gmail.com" },
                    { "e7610feb-110c-47d0-9a88-1bfdc12742a4", 0, "6e85379f-12e9-47af-89cc-8f56eca73ad8", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nahntvt@gmail.com", true, "Khoa", "Nguyen Anh Khoa", false, null, "NAHNTVT@GMAIL.COM", "NAHNTVT@GMAIL.COM", "AQAAAAEAACcQAAAAEAdsvlYt1EtPaljgKS8FpSWwOw/1HARfHzUXFpgscyVoQUo1QGyVKMI6vJx9beWKpg==", "0901234581", false, "", false, "nahntvt@gmail.com" },
                    { "927e4f6a-62ed-4e13-b002-7e133eb47bbc", 0, "294d732c-8e03-43d7-8703-b9fb1b777e1a", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "minhminion2015@gmail.com", true, "Minh", "Luu Bao", false, null, "MINHMINION2015@GMAIL.COM", "MINHMINION2015@GMAIL.COM", "AQAAAAEAACcQAAAAEPqbd54ZBv1YeY9/OYkGVmj7sDHOTwWPsaGzR+zjAuSxmW0EOfn/8p5o4bQDDF6HwA==", "0901234576", false, "", false, "minhminion2015@gmail.com" },
                    { "308da0db-e863-4814-8930-de3540e5406d", 0, "4a81a817-f68b-498d-9abb-e66da37d614d", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tortoise10h@gmail.com", true, "Huy", "Nguyen Tan", false, null, "TORTOISE10H@GMAIL.COM", "TORTOISE10H@GMAIL.COM", "AQAAAAEAACcQAAAAENPACgqbZLxJJt2fMh7Wo/nfwyChPVB8xIUCcIPnpruW1DI3z7CQ+NjfOQIj0FG0LA==", "0397097276", false, "", false, "tortoise10h@gmail.com" },
                    { "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98", 0, "ba493690-af2a-4775-930f-812ce433438c", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoailinhkt2015@gmail.com", true, "Linh", "Luong Tu", false, null, "HOAILINHKT2015@GMAIL.COM", "HOAILINHKT2015@GMAIL.COM", "AQAAAAEAACcQAAAAEDT6/nr99nTU9rDWgxEeBBLOOF+ZlpNwq48HYWJEdnKkdotvahCGS8XEIyTQ353Neg==", "0901234586", false, "", false, "hoailinhkt2015@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tai nghe" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PC Gaming" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PC Văn Phòng" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Linh Kiện PC" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Màn Hình" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bàn Phím" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chuột + Lót Chuột" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ghế Gaming" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "308da0db-e863-4814-8930-de3540e5406d", "b979036b-d165-4bea-b6b6-16b22a3f54dd" },
                    { "927e4f6a-62ed-4e13-b002-7e133eb47bbc", "b979036b-d165-4bea-b6b6-16b22a3f54dd" },
                    { "e7610feb-110c-47d0-9a88-1bfdc12742a4", "b979036b-d165-4bea-b6b6-16b22a3f54dd" },
                    { "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98", "b979036b-d165-4bea-b6b6-16b22a3f54dd" },
                    { "3b488e0f-eb92-4994-a555-cbe4ecdf3672", "5ce20f05-c625-43fc-ae25-a7514e9520db" },
                    { "52999f6b-a605-45b0-b98f-b8880fc46027", "5ce20f05-c625-43fc-ae25-a7514e9520db" },
                    { "39b465e2-c398-494f-bb62-d1eb02aa5471", "5ce20f05-c625-43fc-ae25-a7514e9520db" },
                    { "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16", "5ce20f05-c625-43fc-ae25-a7514e9520db" },
                    { "fd9a7449-e604-48c1-a638-c564e17c1bc0", "5ce20f05-c625-43fc-ae25-a7514e9520db" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name", "Price", "Quantity", "SKU", "Unit" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100% Màu sắc: TRANSPARENT SILVER ", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop Asus D509DA EJ116T", 9300000.0, 20, "D509DA", "Cái" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nhà sản xuất : Dell Xuất xứ : Chính hãng Bảo hành : 12 Tháng Tình trạng : Mới 100%", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop Dell Inspiron 14 5406 N4I5047W", 25000000.0, 13, "N4I5047W", "Cái" },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100%", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop ASUS D409DA EK499T", 9690000.0, 39, "D409DA", "Cái" },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100%", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laptop ASUS D409DA EK499T", 9690000.0, 39, "D409DC", "Cái" },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. <br/> GVN Titan 10 M  sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GVN Titan 10 M", 10500000.0, 39, "D409DAEK499T", "Cái" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ComboId",
                table: "ComboDetails",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetails_ProductId",
                table: "ComboDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDeliveryDetails_GoodsDeliveryNoteId",
                table: "GoodsDeliveryDetails",
                column: "GoodsDeliveryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDeliveryDetails_ProductId",
                table: "GoodsDeliveryDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDeliveryNotes_OrderId",
                table: "GoodsDeliveryNotes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDeliveryNotes_UserId",
                table: "GoodsDeliveryNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingDetails_GoodsReceivingNoteId",
                table: "GoodsReceivingDetails",
                column: "GoodsReceivingNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivingDetails_ProductId",
                table: "GoodsReceivingDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityLogs_ProductId",
                table: "QuantityLogs",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ComboDetails");

            migrationBuilder.DropTable(
                name: "GoodsDeliveryDetails");

            migrationBuilder.DropTable(
                name: "GoodsReceivingDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "QuantityLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "GoodsDeliveryNotes");

            migrationBuilder.DropTable(
                name: "GoodsReceivingNotes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
