using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSiteProject.WebUI.Entity
{
    public class Category
    {   //kategorinin Id'si
        public int Id { get; set; }
        //kategori içeriği
        public string Name { get; set; }
        public string Description { get; set; }
        //tablo ilişkilendirmesi
        public List<Product> Products { get; set; }

    }
}