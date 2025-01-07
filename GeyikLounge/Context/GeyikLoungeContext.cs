using GeyikLounge.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeyikLounge.Context
{
    public class GeyikLoungeContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
    }
}