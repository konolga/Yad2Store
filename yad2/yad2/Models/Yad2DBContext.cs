using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace yad2.Models
{
    public class Yad2DbContext: DbContext, IYadDbContext
    {
        public Yad2DbContext():base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        IQueryable <User> IYadDbContext.Users
        {
            get { return Users; }
        }

        IQueryable<Product> IYadDbContext.Products
        {
            get { return Products; }
        }

        int IYadDbContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IYadDbContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        public Product FindProductById(int? id)
        {
            return Set<Product>().Find(id);
        }

        Product IYadDbContext.FindProductByTitle(string Title)
        {
             Product product = (from p in Set<Product>()
                where p.Title == Title
                select p).FirstOrDefault();
            return product;
        }

        User IYadDbContext.FindUserById(int? id)
        {
            return Set<User>().Find(id);
        }

        T IYadDbContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}