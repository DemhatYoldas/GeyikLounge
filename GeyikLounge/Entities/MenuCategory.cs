using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeyikLounge.Entities
{
    public class MenuCategory
    {
        public int MenuCategoryId { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}