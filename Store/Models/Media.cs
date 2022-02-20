using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Media
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Extension { get; set; }
    }
}
