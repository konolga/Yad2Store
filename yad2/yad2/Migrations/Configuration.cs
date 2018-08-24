using System.Collections.Generic;
using System.IO;
using System.Web;
using System;
using System.Data.Entity.Migrations;
using yad2.Models;



namespace yad2.Migrations
{
 

    internal sealed class Configuration : DbMigrationsConfiguration<Yad2DbContext>


    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Yad2DbContext context)
        {
            base.Seed(context);

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserName = "UserName1",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Email = "email1@gmail.com",
                    Password = "password1",
                    BirthDate = DateTime.Parse("2001-01-01")
                },
                new User
                {
                    Id = 2,
                    UserName = "UserName2",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Email = "email2@gmail.com",
                    Password = "password2",
                    BirthDate = DateTime.Parse("2002-02-02")
                },
                new User
                {
                    Id = 3,
                    UserName = "UserName3",
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Email = "email3@gmail.com",
                    Password = "password3",
                    BirthDate = DateTime.Parse("2003-03-03")
                },
                new User
                {
                    Id = 4,
                    UserName = "UserName4",
                    FirstName = "FirstName4",
                    LastName = "LastName4",
                    Email = "email4@gmail.com",
                    Password = "password4",
                    BirthDate = DateTime.Parse("2004-04-04")
                },
                new User
                {
                    Id = 5,
                    UserName = "UserName5",
                    FirstName = "FirstName5",
                    LastName = "LastName5",
                    Email = "email5@gmail.com",
                    Password = "password5",
                    BirthDate = DateTime.Parse("2005-05-05")
                },
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    UserId = users[1].Id,
                    OwnerId = users[0].Id,
                    Title = "title1",
                    ShortDescription = "short description",
                    LongDescription = "long description",
                    Date = DateTime.Parse("2018-01-01"),
                    Price = 100
                    //,
                    //Picture1 = GetFileBytes("\\Images\\Photo1_1.jpg"),
                    //Picture2 = GetFileBytes("\\Images\\Photo1_2.jpg"),
                    //Picture3 = GetFileBytes("\\Images\\Photo1_3.jpg"),
                },
                new Product
                {
                    Id = 2,
                    UserId = users[1].Id,
                    OwnerId = users[1].Id,
                    Title = "title2",
                    ShortDescription = "short description",
                    LongDescription = "long description",
                    Date = DateTime.Parse("2018-02-02"),
                    Price = 100
                    //,
                    //Picture1 = GetFileBytes("\\Images\\Photo2_1.jpg"),
                    //Picture2 = GetFileBytes("\\Images\\Photo2_2.jpg"),
                    //Picture3 = GetFileBytes("\\Images\\Photo2_3.jpg"),
                },
                new Product
                {
                    Id = 3,
                    UserId = null,
                    OwnerId = users[2].Id,
                    Title = "title3",
                    ShortDescription = "short description",
                    LongDescription = "long description",
                    Date = DateTime.Parse("2018-03-03"),
                    Price = 100
                    //,
                    //Picture1 = GetFileBytes("\\Images\\Photo3_1.jpg"),
                    //Picture2 = GetFileBytes("\\Images\\Photo3_2.jpg"),
                    //Picture3 = GetFileBytes("\\Images\\Photo3_3.jpg"),
                },
                new Product
                {
                    Id = 4,
                    UserId = users[1].Id,
                    OwnerId = null,
                    Title = "title4",
                    ShortDescription = "short description",
                    LongDescription = "long description",
                    Date = DateTime.Parse("2018-04-04"),
                    Price = 100
                   
                    //HttpContext.Current.Server.MapPath("\\Images\\Photo1_1.jpg"))
                    //Picture2 = GetFileBytes("\\Images\\Photo4_2.jpg"),
                    //Picture3 = GetFileBytes("\\Images\\Photo4_3.jpg"),



                },
                new Product
                {
                    Id = 5,
                    UserId = users[1].Id,
                    OwnerId = null,
                    Title = "title5",
                    ShortDescription = "short description",
                    LongDescription = "long description",
                    Date = DateTime.Parse("2018-05-05"),
                    Price = 100,

             //     C:\Users\olgasi\OneDrive\GitProjects\MVC\Project\yad2\yad2\Images\Photo4_1.jpg
             //       Picture1 = GetFileBytes("~/Images/Photo4_1.jpg"),
             //     Picture2 = GetFileBytes("\\Images\\DefaultProduct.jpg")
            //      Picture3 = File.ReadAllBytes(HostingEnvironment.MapPath("\\Images\\Photo4_1"))
            // Picture1= (File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/Photo4_1.jpg")))
            //C:\Users\olgasi\OneDrive\GitProjects\MVC\Project\yad2\yad2\Images\Photo1_1.JPG
            //Picture2 = GetFileBytes("\\Images\\Photo5_2.jpg"),
            //Picture3 = GetFileBytes("\\Images\\Photo5_3.jpg"),
        }
            };
            products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();
        }

        public byte[] GetFileBytes(string path)
        {
            using (var fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return fileBytes;
            }
        }


        //        byte[] GetFileBytes(HttpPostedFileBase path)
        //{
        //    Image img = Image.FromFile(path.FileName);
        //    byte[] arr;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        arr = ms.ToArray();
        //    }
        //    return arr;
        //}


    }


}





