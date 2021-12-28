using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;

namespace Store.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> PageProducts { get; set; }
        public PageViewModel OnePageViewModel { get; set; }
        public ForWho CurrentOption { get; set; }
    }
}
