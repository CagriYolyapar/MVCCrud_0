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
    public class CategoryController : Controller
    {

        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }


        public ActionResult ListCategories()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(cvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }


        //Eger Front End'den size paketlenmiş bir model geliyorsa (ViewModel veya Tuple gibi) mecburi bir şekilde o gelen veriyi o tiple BackEnd'de karsılamak durumundasınız...Lakin sizin istediginiz o tipin tamamıyla kendisi olabilir.. Ancak gelen modelin icerisinden spesifik bir tipi yakalamak istiyorsanız o zaman iki seceneginiz vardır

        //1 => Parametre isminin bagımsız kalabilmesi acısından ilgili tipi Bind keyword'u ile yakalamaktır...Prefix'te yakalamak istediginiz tip Encapsulation yapılmıs tipin icerisinde hangi property ismiyle yer alıyorsa o isimle Prefix ile yakalanır...public ActionResult AddCategory([Bind(Prefix ="Category")]Category item)

        //2=> Yakalamak istediginiz tip Encapsulation yapılmıs tip icerisinde hangi property ismiyle geciyorsa incasesensitive(yani kücük büyük harf duyarlı olmadan) o isme sahip parametre olarak Post Action'ına verilir...

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _db.Categories.Find(id)
            };

            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            Category guncellenecek = _db.Categories.Find(category.CategoryID);

            guncellenecek.CategoryName = category.CategoryName;
            guncellenecek.Description = category.Description;
            _db.SaveChanges();

            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }


    }
}