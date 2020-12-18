using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using api.Entities;
using api.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System;
using api.Common.Enums;

namespace api.Helpers
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GoodsReceivingNote> GoodsReceivingNotes { get; set; }
        public DbSet<GoodsReceivingDetail> GoodsReceivingDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<GoodsDeliveryNote> GoodsDeliveryNotes { get; set; }
        public DbSet<GoodsDeliveryDetail> GoodsDeliveryDetails { get; set; }

        protected readonly IConfiguration Configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions options, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            Configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            /** Connect to database here */
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigDBTablesRelationship();

            modelBuilder.ConfigTablesRequirements();

            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AutoTrack();
            int result = await base.SaveChangesAsync();

            return result;
        }

        private void AutoTrack()
        {
            /** Auto apply info of user and time every time entity is modified */
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).CreatedBy = _httpContextAccessor.HttpContext.User.Claims.Count() > 0
                        ? _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value
                        : null;
                }

                ((BaseEntity)entity.Entity).LastModifiedAt = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).LastModifiedBy = _httpContextAccessor.HttpContext.User.Claims.Count() > 0
                        ? _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "id").Value
                        : null;
            }
        }
    }
}