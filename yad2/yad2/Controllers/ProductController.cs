
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using yad2.Models;

namespace yad2.Controllers
{
    public class ProductController : Controller
    {
        private Yad2DbContext db = new Yad2DbContext();

        // GET: Products
        public ActionResult Index(int number)
        {
            List<Product> products;
            if (number == 0)
            {
                products = db.Products.ToList();
            }
            else
            {
                products = (from p in db.Products orderby p.Id descending select p).Take(number).ToList();
            }

            return PartialView("_ProductPreview", products);
        }

        //  GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View("Details", product);
        }

        //    GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Users, "ID", "FirstName");
            ViewBag.UserId = new SelectList(db.Users, "ID", "FirstName");
            return View();
        }

        //   POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var users = db.Users.ToList();
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                int? loggedUserId = users.Find(u => u.UserName == username)?.Id;
                using (Yad2DbContext context = new Yad2DbContext())
                {
                    try
                    {
                        Product newProduct = new Product()
                        {
                            Title = product.Title,
                            ShortDescription = product.ShortDescription,
                            LongDescription = product.LongDescription,
                            Price = product.Price,
                            Date = DateTime.Now,
                            UserId = loggedUserId,
                            OwnerId = loggedUserId,
                            State = 0,
                            Picture1 = product.Picture1,
                            Picture2 = product.Picture2,
                            Picture3 = product.Picture3
                        };



                        if (image != null)
                        {
                            image.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                 + image.FileName);

                            newProduct.Picture1 = "\\Images\\" + image.FileName;

                        }
                        context.Products.Add(newProduct);
                        context.SaveChanges();
                        return RedirectToAction("Details", "Product", new { iD = newProduct.Id });


                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("Error",  "error: " + e.Message.ToString());
                    }
                }
            }
            return View();

        }

        //   GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.OwnerId = new SelectList(db.Users, "ID", "FirstName", product.OwnerId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "FirstName", product.UserId);
            return View(product);
        }

        //POST: Products/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
                "ID,OwnerId,UserId,Title,ShortDescription,LongDescription,Date,Price,Picture1,Picture2,Picture3,State")]
            Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Users, "ID", "FirstName", product.OwnerId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "FirstName", product.UserId);
            return View(product);
        }

        //   GET: Products/Delete/5
        public ActionResult Disable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        //  POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DisableConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.State = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        [OutputCache(Duration = 600, Location = OutputCacheLocation.Server, VaryByParam = "id")]
        public FileContentResult GetProductImage(int id, int index)
        {
            Product product = db.Set<Product>().Find(id);
            FileContentResult res = null;

            if (product != null)
            {
                switch (index)
                {
                    case 1:
                        if (product.Picture1 != null) res = File(GetFileBytes(product.Picture1), "jpg");
                        break;
                    case 2:
                        if (product.Picture2 != null) res = File(GetFileBytes(product.Picture2), "jpg");
                        break;
                    case 3:
                        if (product.Picture3 != null) res = File(GetFileBytes(product.Picture3), "jpg");
                        break;
                }
            }

            if (res == null)
            {
                return File(GetFileBytes("\\Images\\DefaultProduct.jpg"), "jpg");
            }
            else return res;

        }

        [ChildActionOnly]
        public ActionResult _ProductPreview(string sortOrder, int number = 0)
        {
            List<Product> listView = new List<Product>();
            if (Session["view"] == null)
            {
                //create session if it is not exist yet
                listView = db.Products.Where(x => x.State == 0).ToList();
                Session["view"] = listView;
            }
            else
            {
                listView = (List<Product>)Session["view"];
                Session["view"] = listView;
            }

            // if we want to show all avaliable products
            if (number == 0)
            {
                //  show all products
                switch (sortOrder)
                {
                    case "name":
                        listView = listView.OrderBy(x => x.Title).ToList();
                        break;

                    case "date":
                        listView = listView.OrderBy(x => x.Date).ToList();
                        break;
                    default:
                        break;
                }

            }

            //  if we want to show specific product
            else
            {
                listView = (from p in listView orderby p.Date descending select p).Take(number).ToList();
            }
            Session["view"] = listView;
            return PartialView("_ProductPreview", listView);
        }


        public byte[] GetFileBytes(string path)
        {
            //exception - to describe here
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

        public int GetPrice(int? id)
        {
            Product product = db.FindProductById(id);

            int price = product.Price;

            if (product != null && Request.IsAuthenticated)
            {
                return product.Price = (int)(price * 0.9);
            }

            if (product != null && !Request.IsAuthenticated)
            {
                return product.Price = price;
            }
            else return 0;
        }



        }

    }


