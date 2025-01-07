using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeyikLounge.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}