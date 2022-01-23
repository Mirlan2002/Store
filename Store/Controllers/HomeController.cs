using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Store.ViewModels;
using System.Collections.Generic;


namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index(ForWho option, int page=1)
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
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageProducts = items,
                OnePageViewModel = pageViewModel,
                CurrentOption = option
            };
            return View(viewModel);
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
