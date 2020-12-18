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
                .HasQueryFilter(o => EF.Property<bool>(o, "IsDeleted") == false);

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
        }
    }
}