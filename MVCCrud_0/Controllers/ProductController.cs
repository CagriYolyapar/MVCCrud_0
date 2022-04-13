using MVCCrud_0.DesignPatterns.SingletonPattern;
using MVCCrud_0.Models;
using MVCCrud_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud_0.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities _db;

        public ProductController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: Product
        public ActionResult ListProducts()
        {
            ProductVM pvm = new ProductVM
            {
                Products = _db.Products.ToList()
            };
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _db.Categories.ToList(),
                Product = _db.Products.Find(id)
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            Product guncellenecek = _db.Products.Find(product.ProductID);
            guncellenecek.ProductName = product.ProductName;
            guncellenecek.UnitPrice = product.UnitPrice;
            guncellenecek.CategoryID = product.CategoryID != null ? product.CategoryID : null;
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }
    }
}