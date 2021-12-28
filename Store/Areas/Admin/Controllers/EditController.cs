using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Store.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;



namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditController : Controller
    {
        private ApplicationContext db;
        IWebHostEnvironment hostingEnvironment;

        public EditController(ApplicationContext context, IWebHostEnvironment env)
        {
            hostingEnvironment = env;
            db = context;
        }

        public IActionResult Edit(int id)
        {
            var item = id == default ? new Product() : db.Products.FirstOrDefault(x => x.Id == id);
            return View(item);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    product.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                if(product.Id == default)
                {
                    db.Products.Add(product);
                }
                else
                {
                    db.Products.Update(product);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }






        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if(id != default)
            {
                Product product = db.Products.FirstOrDefault(x => x.Id == id);
                return View(product);
            }
            return NotFound();
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id != default)
            {
                var product = db.Products.FirstOrDefault(x => x.Id == id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
    }
}
