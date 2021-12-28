using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public enum ForWho
    {
        [Display(Name="Все")]
        All,

        [Display(Name ="Мужские")]
        Mens,

        [Display(Name ="Женские")]
        Womens,

        [Display(Name ="Детские")]
        Kids
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string TitleImagePath { get; set; }
        public string Description { get; set; }
        public ForWho ForHuman { get; set; }
    }
}
