﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexBE.Domain.Models;

namespace VortexBE.Domain.Seed
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var fecha = DateTime.UtcNow;
            int id = 1, idlist = 0;
            var faker = new Faker();
            var random = new Random();

            /*
            #region Category
            var listCat = new string[] { "Technology", "Clothes", "Food", "House", "Sport" };

            var fakerCategory = new Bogus.Faker<Category>()
                .RuleFor(x => x.id, f => id++)
                .RuleFor(x => x.name, f => listCat[idlist++])
                .RuleFor(x => x.slug, f => f.Lorem.Word())
                .RuleFor(x => x.image, f => f.Image.PicsumUrl())
                .RuleFor(x => x.creationAt, f => fecha)
                .RuleFor(x => x.updatedAt, f => fecha);

            var listCategory = fakerCategory.Generate(5);
            foreach (var c in listCategory)
                modelBuilder.Entity<Category>().HasData(c);
            #endregion

            #region Product
            id = 1;
            var allImages = new List<string>();
            for (var i = 0; i <= 100; i++)
                allImages.Add(faker.Image.PicsumUrl());


            var fakerProducts = new Bogus.Faker<Product>()
                .RuleFor(x => x.id, f => id++)
                .RuleFor(x => x.title, f => f.Commerce.ProductName())
                .RuleFor(x => x.slug, f => f.Lorem.Word())
                .RuleFor(x => x.price, f => random.Next(15, 99))
                .RuleFor(x => x.description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.categoryId, f => listCategory[random.Next(listCategory.Count)].id)
                .RuleFor(x => x.images, f => allImages.Take(random.Next(2, 5)).ToList())
                .RuleFor(x => x.creationAt, f => fecha)
                .RuleFor(x => x.updatedAt, f => fecha);

            var listProducts = fakerProducts.Generate(100);
            foreach (var p in listProducts)
                modelBuilder.Entity<Product>().HasData(p);
            #endregion
            */

            #region Users
            id = 1;
            var fakerUser = new Bogus.Faker<User>()
                .RuleFor(x => x.UserId, f => id++)
                .RuleFor(x => x.Username, f => "Juan")
                .RuleFor(x => x.PasswordHash, f => Encrypt.MD5("1234"))
                .RuleFor(x => x.creationAt, f => fecha)
                .RuleFor(x => x.updatedAt, f => fecha);

            var listUsers = fakerUser.Generate(1);
            foreach (var u in listUsers)
                modelBuilder.Entity<User>().HasData(u);
            #endregion

        }
    }
}
