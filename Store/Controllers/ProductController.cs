using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    public class ProductController:Controller
    {
        private ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Media = db.Medias.Where(x => x.ProductId == id);
            return View(db.Products.FirstOrDefault(x => x.Id == id));
        }
    }
}
