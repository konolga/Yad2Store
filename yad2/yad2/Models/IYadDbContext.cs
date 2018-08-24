using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yad2.Models
{
    interface IYadDbContext
    {
        IQueryable<User> Users { get; }
        IQueryable<Product> Products { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Product FindProductById(int? ID);
        Product FindProductByTitle(string Title);
        User FindUserById(int? ID);
        T Delete<T>(T entity) where T : class;
    }
}
