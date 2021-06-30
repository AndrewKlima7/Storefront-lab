using Microsoft.AspNetCore.Mvc;
using Storefront_lab_Andrew_Klima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront_lab_Andrew_Klima.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        public IActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        //Delete
        public IActionResult Delete(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        //Update
        public IActionResult Update(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Update(Product p)
        {
            db.Products.Update(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        //Details
        public IActionResult Details(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }

        //Add
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
