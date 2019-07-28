using System.Collections.Generic;
using DinnerBooking.Data.Entities;

namespace DinnerBooking.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DinnerBooking.Data.BaseEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DinnerBooking.Data.BaseEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<Category> categories = new List<Category>();
            categories.Add(new Category() { CategoryId=1, CategoryName= "�O����" });
            categories.Add(new Category() { CategoryId = 2, CategoryName = "�p�v����" });
            categories.Add(new Category() { CategoryId = 3, CategoryName = "�S�����s" });
            categories.ForEach(a => context.Category.AddOrUpdate(a));
            List<Cuisine> cuisines = new List<Cuisine>();
            cuisines.Add(new Cuisine() { Id = 1, Name= "�����ޥ��s", CategoryId=1 ,Detail= "�ڦ�ޥ��t�������ơC", Count=5, Price=43 });
            cuisines.Add(new Cuisine() { Id = 2, Name = "�@�f�M��", CategoryId = 1, Detail = "�׽��A��A�J�f�Y���C", Count = 6, Price = 35 });
            cuisines.Add(new Cuisine() { Id = 3, Name = "�S���γJ��", CategoryId = 1, Detail = "�r���n�ܡA�R���J���C", Count = 7, Price = 28 });
            cuisines.Add(new Cuisine() { Id = 4, Name = "�馡�K��", CategoryId = 1, Detail = "�M�������A²���o�C", Count = 7, Price = 33 });
            cuisines.Add(new Cuisine() { Id = 5, Name = "�¯��F��", CategoryId = 2, Detail = "�����H�h����C", Count = 8, Price = 45 });
            cuisines.Add(new Cuisine() { Id = 6, Name = "�����A�ץ�", CategoryId = 2, Detail = "�件��n�C", Count = 9, Price = 38 });
            cuisines.Add(new Cuisine() { Id = 7, Name = "�X�l�ѥ]", CategoryId = 3, Detail = "�C�魭�q�C", Count = 10, Price = 50 });
            cuisines.Add(new Cuisine() { Id = 8, Name = "�̯ȹإq��", CategoryId = 3, Detail = "�O���@�f�����C", Count = 20, Price = 48 });
            cuisines.Add(new Cuisine() { Id = 9, Name = "�䦡�~���]", CategoryId = 3, Detail = "���O���D�A����ѳ��C", Count = 30, Price = 52 });
            cuisines.ForEach(a => context.Cuisine.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
