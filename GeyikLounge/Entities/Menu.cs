using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeyikLounge.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }
    }
}