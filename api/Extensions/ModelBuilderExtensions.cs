using api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using api.Common.Enums;

namespace api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigDBTablesRelationship(this ModelBuilder modelBuilder)
        {

        }

        public static void ConfigTablesRequirements(this ModelBuilder modelBuilder)
        {
            /** ProductCategory */
            modelBuilder
                .Entity<Category>()
                .HasQueryFilter(pc => EF.Property<bool>(pc, "IsDeleted") == false);

            /** Product */
            modelBuilder
                .Entity<Product>()
                .HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

            /** GoodsReceivingNote */
            modelBuilder
                .Entity<GoodsReceivingNote>()
                .HasQueryFilter(ppd => EF.Property<bool>(ppd, "IsDeleted") == false);

            /** GoodsReceivingDetail */
            modelBuilder
                .Entity<GoodsReceivingDetail>()
                .HasQueryFilter(ppd => EF.Property<bool>(ppd, "IsDeleted") == false);

            /** Order */
            modelBuilder
                .Entity<Order>()
                .HasQueryFilter(o => EF.Property<bool>(o, "IsDeleted") == false)
                .Ignore(o => o.Customer);

            /** OrderDetail */
            modelBuilder
                .Entity<OrderDetail>()
                .HasQueryFilter(od => EF.Property<bool>(od, "IsDeleted") == false);

            /** GoodsDeliveryNote */
            modelBuilder
                .Entity<GoodsDeliveryNote>()
                .HasQueryFilter(gdn => EF.Property<bool>(gdn, "IsDeleted") == false);

            /** GoodsDeliveryDetail */
            modelBuilder
                .Entity<GoodsDeliveryDetail>()
                .HasQueryFilter(gdd => EF.Property<bool>(gdd, "IsDeleted") == false);

            /** QuantityLog */
            modelBuilder
                .Entity<QuantityLog>()
                .HasQueryFilter(gdd => EF.Property<bool>(gdd, "IsDeleted") == false);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            /*------------------------------------
             |                                   |
             |       SEED USERS AND ROLES        |
             |                                   |
             |-----------------------------------| */
            string adminRoleId = "b979036b-d165-4bea-b6b6-16b22a3f54dd";
            string customerRoleId = "5ce20f05-c625-43fc-ae25-a7514e9520db";

            string admin1Id = "308da0db-e863-4814-8930-de3540e5406d";
            string admin2Id = "927e4f6a-62ed-4e13-b002-7e133eb47bbc";
            string admin3Id = "e7610feb-110c-47d0-9a88-1bfdc12742a4";
            string admin4Id = "e9012ef1-cd3c-49a1-8726-7f8f8aba9f98";

            string customer1Id = "3b488e0f-eb92-4994-a555-cbe4ecdf3672";
            string customer2Id = "52999f6b-a605-45b0-b98f-b8880fc46027";
            string customer3Id = "39b465e2-c398-494f-bb62-d1eb02aa5471";
            string customer4Id = "ce4b2f5c-1fb9-4fe1-945c-20eca474ce16";
            string customer5Id = "fd9a7449-e604-48c1-a638-c564e17c1bc0";


            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "admin"
                    },
                    new IdentityRole
                    {
                        Id = customerRoleId,
                        Name = "Customer",
                        NormalizedName = "customer"
                    }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>()
                .HasData(
                    new ApplicationUser
                    {
                        Id = admin1Id,
                        FirstName = "Huy",
                        LastName = "Nguyen Tan",
                        UserName = "tortoise10h@gmail.com",
                        NormalizedUserName = "tortoise10h@gmail.com".ToUpper(),
                        Email = "tortoise10h@gmail.com",
                        NormalizedEmail = "tortoise10h@gmail.com".ToUpper(),
                        PhoneNumber = "0397097276",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = admin2Id,
                        FirstName = "Minh",
                        LastName = "Luu Bao",
                        UserName = "minhminion2015@gmail.com",
                        NormalizedUserName = "minhminion2015@gmail.com".ToUpper(),
                        Email = "minhminion2015@gmail.com",
                        NormalizedEmail = "minhminion2015@gmail.com".ToUpper(),
                        PhoneNumber = "0901234576",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = admin3Id,
                        FirstName = "Khoa",
                        LastName = "Nguyen Anh Khoa",
                        UserName = "nahntvt@gmail.com",
                        NormalizedUserName = "nahntvt@gmail.com".ToUpper(),
                        Email = "nahntvt@gmail.com",
                        NormalizedEmail = "nahntvt@gmail.com".ToUpper(),
                        PhoneNumber = "0901234581",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = admin4Id,
                        FirstName = "Linh",
                        LastName = "Luong Tu",
                        UserName = "hoailinhkt2015@gmail.com",
                        NormalizedUserName = "hoailinhkt2015@gmail.com".ToUpper(),
                        Email = "hoailinhkt2015@gmail.com",
                        NormalizedEmail = "hoailinhkt2015@gmail.com".ToUpper(),
                        PhoneNumber = "0901234586",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = customer1Id,
                        FirstName = "Huy",
                        LastName = "Nguyen Tan",
                        UserName = "ngtanhu99@gmail.com",
                        NormalizedUserName = "ngtanhu99@gmail.com".ToUpper(),
                        Email = "ngtanhu99@gmail.com",
                        NormalizedEmail = "ngtanhu99@gmail.com".ToUpper(),
                        PhoneNumber = "0764928878",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = customer2Id,
                        FirstName = "Minh",
                        LastName = "Luu Bao",
                        UserName = "luubaominh@gmail.com",
                        NormalizedUserName = "luubaominh@gmail.com".ToUpper(),
                        Email = "luubaominh@gmail.com",
                        NormalizedEmail = "luubaominh@gmail.com".ToUpper(),
                        PhoneNumber = "0901234564",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = customer3Id,
                        FirstName = "Khoa",
                        LastName = "Nguyen Anh",
                        UserName = "s2nak@gmail.com",
                        NormalizedUserName = "s2nak@gmail.com".ToUpper(),
                        Email = "s2nak@gmail.com",
                        NormalizedEmail = "s2nak@gmail.com".ToUpper(),
                        PhoneNumber = "0901234572",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = customer4Id,
                        FirstName = "Linh",
                        LastName = "Luong Tu",
                        UserName = "luongtulinh@gmail.com",
                        NormalizedUserName = "luongtulinh@gmail.com".ToUpper(),
                        Email = "luongtulinh@gmail.com",
                        NormalizedEmail = "luongtulinh@gmail.com".ToUpper(),
                        PhoneNumber = "0901234561",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    },
                    new ApplicationUser
                    {
                        Id = customer5Id,
                        FirstName = "Tú",
                        LastName = "Trương Tuấn",
                        UserName = "truongtuantu@gmail.com",
                        NormalizedUserName = "truongtuantu@gmail.com".ToUpper(),
                        Email = "truongtuantu@gmail.com",
                        NormalizedEmail = "truongtuantu@gmail.com".ToUpper(),
                        PhoneNumber = "0901234578",
                        CreatedAt = new DateTime(2020, 1, 1),
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = admin1Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = admin2Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = admin3Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = admin4Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = customerRoleId,
                        UserId = customer1Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = customerRoleId,
                        UserId = customer2Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = customerRoleId,
                        UserId = customer3Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = customerRoleId,
                        UserId = customer4Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = customerRoleId,
                        UserId = customer5Id
                    }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Laptop"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "PC Gaming"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "PC Văn Phòng"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Linh Kiện PC"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Màn Hình"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Bàn Phím"
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Chuột + Lót Chuột"
                    },
                    new Category
                    {
                        Id = 8,
                        Name = "Tai nghe"
                    },
                    new Category
                    {
                        Id = 9,
                        Name = "Ghế Gaming"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Laptop Asus D509DA EJ116T",
                        Description = "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100% Màu sắc: TRANSPARENT SILVER ",
                        Unit = "Cái",
                        Price = 9300000,
                        SKU = "D509DA",
                        Quantity = 20,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Laptop Dell Inspiron 14 5406 N4I5047W",
                        Description = "Nhà sản xuất : Dell Xuất xứ : Chính hãng Bảo hành : 12 Tháng Tình trạng : Mới 100%",
                        Unit = "Cái",
                        Price = 25000000,
                        SKU = "N4I5047W",
                        Quantity = 13,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Laptop ASUS D409DA EK499T",
                        Description = "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100%",
                        Unit = "Cái",
                        Price = 9690000,
                        SKU = "D409DA",
                        Quantity = 39,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Laptop ASUS D409DA EK499T",
                        Description = "Nhà sản xuất : ASUS Xuất xứ : Chính hãng Bảo hành : 24 Tháng Tình trạng : Mới 100%",
                        Unit = "Cái",
                        Price = 9690000,
                        SKU = "D409DC",
                        Quantity = 39,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "GVN Titan 10 M",
                        Description = "Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. <br/> GVN Titan 10 M  sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.",
                        Unit = "Cái",
                        Price = 10500000,
                        SKU = "D409DAEK499T",
                        Quantity = 39,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "GVN Ghosts S",
                        Description = "Trong tầm giá 23 triệu đồng GVN Ghosts S sẽ là một trong những sự lựa chọn tốt nhất mang đến những trải nghiệm với các dòng game đồi hỏi đồ họa cao. Vừa kinh tế vừa mang lại hiệu năng cao.",
                        Unit = "Cái",
                        Price = 21290000,
                        SKU = "D409DAE9T",
                        Quantity = 12,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Core i5 9400F / 9M / 2.9GHz / 6 nhân 6 luồng",
                        Description = "Core i5 9400F / 9M / 2.9GHz / 6 nhân 6 luồng",
                        Unit = "Cái",
                        Price = 3490000,
                        SKU = "i59m9400F",
                        Quantity = 12,
                        CategoryId = 4
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "( 650W ) Nguồn máy tính SilverStone ST65F-ES230 80 Plus",
                        Description = "( 650W ) Nguồn máy tính SilverStone ST65F-ES230 80 Plus",
                        Unit = "Cái",
                        Price = 1190000,
                        SKU = "ST65F-ES23080Plus",
                        Quantity = 30,
                        CategoryId = 4
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "Gigabyte SSD 240GB 2.5\" Sata 3 ( GP-GSTFS31240GNTD )",
                        Description = "Gigabyte SSD 240GB 2.5\" Sata 3 ( GP-GSTFS31240GNTD )",
                        Unit = "Cái",
                        Price = 750000,
                        SKU = "GP-GSTFS31240GNTD",
                        Quantity = 22,
                        CategoryId = 4
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Màn hình LG 22MN430M-B 22\" IPS 75Hz FreeSync",
                        Description = "Màn hình LG 22MN430M-B 22\" IPS 75Hz FreeSync",
                        Unit = "Cái",
                        Price = 2890000,
                        SKU = "22MN430M-B",
                        Quantity = 22,
                        CategoryId = 5
                    },
                    new Product
                    {
                        Id = 11,
                        Name = "Màn hình LG 24MP88HV-S 24\" IPS không viền",
                        Description = "Màn hình LG 24MP88HV-S 24\" IPS không viền",
                        Unit = "Cái",
                        Price = 3890000,
                        SKU = "24MP88HV-S",
                        Quantity = 10,
                        CategoryId = 5
                    }
                );

            modelBuilder.Entity<Combo>()
                .HasData(
                    new Combo
                    {
                        Id = 1,
                        Name = "Combo noel",
                        DiscountPercentage = 5,
                        Price = 14380000,
                        PriceForSale = 13661000,
                    }
                );

            modelBuilder.Entity<ComboDetail>()
                .HasData(
                    new ComboDetail
                    {
                        Id = 1,
                        ProductId = 11,
                        ComboId = 1,
                        Quantity = 1,
                    },
                    new ComboDetail
                    {
                        Id = 2,
                        ProductId = 8,
                        ComboId = 1,
                        Quantity = 1,
                    },
                    new ComboDetail
                    {
                        Id = 3,
                        ProductId = 1,
                        ComboId = 1,
                        Quantity = 1,
                    }
                );
        }
    }
}