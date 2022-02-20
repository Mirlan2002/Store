using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Microsoft.EntityFrameworkCore;
using Store.ViewModels;


namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index(ForWho option, int page = 1)
        {
            int pageSize = 3; //количество элементов на странице
            IQueryable<Product> source;
            if (option == default)
            {
                source = db.Products;
            }
            else
            {
                source = db.Products.Where(x => x.ForHuman == option).Union(db.Products.Where(x => x.ForHuman == ForWho.All));
            }
            int count = source.Count();
            var products = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            Dictionary<Product, IEnumerable<Media>> items = new Dictionary<Product, IEnumerable<Media>>();
            foreach (var p in products)
            {
                items[p] = db.Medias.Where(x => x.ProductId == p.Id);
            }

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageProducts = items,
                OnePageViewModel = pageViewModel,
                CurrentOption = option
            };
            return View(viewModel);
        }
    }
}
