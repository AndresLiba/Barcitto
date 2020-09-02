using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Barcitto.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }



        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }

   
}
