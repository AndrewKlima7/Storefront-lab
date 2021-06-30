using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storefront_lab_Andrew_Klima.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront_lab_Andrew_Klima.Controllers
{
    public class StorefrontController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        public IActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        public IActionResult Buy(int Id)
        {
            Product p = db.Products.Find(Id);
            return View(p);
        }

        public IActionResult Result(Product p)
        {
            if(p.Quantity > 0)
            {
                p.Quantity = (int) p.Quantity - 1;
                db.Products.Update(p);
                db.SaveChanges();
            }

            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
