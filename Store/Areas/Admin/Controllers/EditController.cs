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
            ViewBag.Media = db.Medias.Where(x => x.ProductId == id);
            var item = id == default ? new Product() : db.Products.FirstOrDefault(x => x.Id == id);
            return View(item);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile titleImageFile, IFormFileCollection uploads)
        {
            if (ModelState.IsValid)
            {
                int productId = 0;
                if (product.Id == default)
                {
                    db.Products.Add(product);
                    await db.SaveChangesAsync();
                }
                else
                {
                    db.Products.Update(product);
                    await db.SaveChangesAsync();
                }
                productId = product.Id;
                if (titleImageFile != default)
                {
                    if (product.TitleImagePath != default)
                    {
                        FileInfo fileInf = new FileInfo(hostingEnvironment.WebRootPath + "/img/productimg/" + product.TitleImagePath);
                        if (fileInf.Exists)
                        {
                            fileInf.Delete();
                        }
                    }
                    product.TitleImagePath = productId + Path.GetExtension(titleImageFile.FileName);
                    db.Products.Update(product);
                    await db.SaveChangesAsync();
                    string path = hostingEnvironment.WebRootPath + "/img/productimg/" + productId + Path.GetExtension(titleImageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                foreach (var uploadedFile in uploads)
                {
                    if (uploadedFile != default)
                    {
                        Media media = new Media { ProductId = productId, Extension = Path.GetExtension(uploadedFile.FileName) };
                        db.Medias.Add(media);
                        await db.SaveChangesAsync();
                        string filePath = hostingEnvironment.WebRootPath + "/img/images/" + media.Id + Path.GetExtension(uploadedFile.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            uploadedFile.CopyTo(stream);
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }






        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if (id != default)
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
                FileInfo fileInf = new FileInfo(hostingEnvironment.WebRootPath + "/img/productimg/" + product.TitleImagePath);
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }
                IQueryable<Media> medias = db.Medias.Where(x => x.ProductId == id);
                foreach (Media m in medias)
                {
                    FileInfo fI = new FileInfo(hostingEnvironment.WebRootPath + "/img/images/" + m.Id + m.Extension);
                    if (fI.Exists)
                    {
                        fI.Delete();
                    }
                }
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }



        [HttpPost]
        public int DeleteTitleImage()
        {
            return StatusCodes.Status200OK;
        }
    }
}
