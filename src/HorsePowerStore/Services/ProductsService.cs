﻿using HorsePowerStore.Data;
using HorsePowerStore.Models;
using HorsePowerStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorsePowerStore.Services
{
    public class ProductsService
    {
        private ApplicationDbContext db;

        public ProductsService (ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<ProductViewModel> ListProducts (int start, int amount)
        {
            return db.Products
                .Skip(start).Take(amount)
                .Include(p => p.Ratings)
                .Select(p => new ProductViewModel()
                {
                    Id=p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    AverageRating = p.Ratings.Select(r => r.Value).DefaultIfEmpty().Average(),
                    ImageSource = p.ImageSource,
                    PurchaseURL = p.PurchaseURL
                }).ToList();
        }

        public ProductViewModel GetProductWithRatings (int id, int start, int amount)
        {
            return (
                from p in db.Products
                where p.Id == id
                select p)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    AverageRating = p.Ratings.Select(r => r.Value).DefaultIfEmpty().Average(),
                    Ratings = p.Ratings.Skip(start).Take(amount).ToList(),
                    ImageSource = p.ImageSource,
                    PurchaseURL = p.PurchaseURL
                })
                .FirstOrDefault();
        }

        public void AddRating (int id, Rating rating, string userName)
        {
            var product = (
                from p in db.Products
                where p.Id == id
                select p)
                .Include(p => p.Ratings)
                .FirstOrDefault();
            if (product == null) return;

            var user = (
                from u in db.AppUsers
                where u.UserName == userName
                select u)
                .Include(u => u.Ratings)
                .FirstOrDefault();

            if (user.Ratings.Intersect(product.Ratings).Count() > 0) return;

            product.Ratings.Add(rating);
            user.Ratings.Add(rating);
            db.SaveChanges();
        }

        public void RemoveRating(int ratingId, string userName)
        {
            var rating = (
                from r in db.Ratings
                where r.Id == ratingId
                select r)
                .FirstOrDefault();

            var user = (
                from u in db.AppUsers
                where u.UserName == userName
                select u)
                .FirstOrDefault();

            if (rating == null || 
                !user.Ratings.Contains(rating)) return;

            db.Ratings.Remove(rating);
            db.SaveChanges();
        }
    }
}
