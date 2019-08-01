using System;
using System.Configuration;
using DinnerBooking.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DinnerBooking.Core.Data
{
    public class BaseEntities : DbContext
    {
        public BaseEntities(DbContextOptions<BaseEntities> options) : base(options) { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CategorySeed
            modelBuilder.Entity<Category>().HasData(new Category() { CategoryId = 1, CategoryName = "是日精選" });
            modelBuilder.Entity<Category>().HasData(new Category() { CategoryId = 2, CategoryName = "廚師推介" });
            modelBuilder.Entity<Category>().HasData(new Category() { CategoryId = 3, CategoryName = "特價推廣" });
            #endregion
            #region CuisineSeed
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 1, Name = "泰式豬扒煲", CategoryId = 1, Detail = "巴西豬扒配泰式香料。", Count = 5, Price = 43 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 2, Name = "一口和牛", CategoryId = 1, Detail = "肉質鮮嫩，入口即溶。", Count = 6, Price = 35 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 3, Name = "惹味煎蛋餅", CategoryId = 1, Detail = "咬落爽脆，充滿蛋香。", Count = 7, Price = 28 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 4, Name = "日式便當", CategoryId = 1, Detail = "和式風味，簡單精緻。", Count = 7, Price = 33 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 5, Name = "純素沙律", CategoryId = 2, Detail = "素食人士必選。", Count = 8, Price = 45 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 6, Name = "辣炒翠肉瓜", CategoryId = 2, Detail = "邊辣邊爽。", Count = 9, Price = 38 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 7, Name = "出爐麵包", CategoryId = 3, Detail = "每日限量。", Count = 10, Price = 50 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 8, Name = "米紙壽司卷", CategoryId = 3, Detail = "別有一番風味。", Count = 20, Price = 48 });
            modelBuilder.Entity<Cuisine>().HasData(new Cuisine() { Id = 9, Name = "港式漢堡包", CategoryId = 3, Detail = "茶記味道，不輸老麥。", Count = 30, Price = 52 });
            #endregion
            
        }
    }
}
