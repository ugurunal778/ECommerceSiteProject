using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ECommerceSiteProject.WebUI.Entity
{
    public class Product
    {   //ürün Id'si
        public int Id { get; set; }
        //Ürün içeriği
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double Price { get; set; }
        [DisplayName("Ürün Stoğu")]
        public int Stock{ get; set; }
        public string Image { get; set; }
        [DisplayName("Anasayfa Ürünü")]
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        //tablo ilişkilendirmesi
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}