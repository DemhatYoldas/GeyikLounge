using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static GeyikLounge.Entities.Category;

namespace GeyikLounge.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}