using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ECommerceSiteProject.WebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name = "Kamera", Description="Kamera Ürünleri"},
                new Category(){Name = "Bilgisayar", Description="Bilgisayar Ürünleri"},
                new Category(){Name = "Elektronik", Description="Elektronik Ürünleri"},
                new Category(){Name = "Telefon", Description="Telefon Ürünleri"},
                new Category(){Name = "Beyaz Eşya", Description="Beyaz Eşya Ürünleri"},
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>
            {
                new Product(){Name="Canon Eos 1200D Fotoğraf Makinesi",Description="1 numaralı fotoğraf makinesi", Price=3500,Stock=50,IsApproved=true,CategoryId=1, Image="1.jpg", IsHome=true},
                new Product(){Name="Canon Eos 700D Fotoğraf Makinesi",Description="2 numaralı fotoğraf makinesi", Price=3000,Stock=50,IsApproved=true,CategoryId=1, Image="1.jpg"},

                new Product(){Name="Dell Laptop",Description="1 numaralı Laptop", Price=7500,Stock=50,IsApproved=true,CategoryId=2, Image="2.jpg", IsHome=true},
                new Product(){Name="Asus Laptop",Description="2 numaralı Laptop", Price=5000,Stock=50,IsApproved=true,CategoryId=2, Image="2.jpg"},

                new Product(){Name="Samsung Tv",Description="1 numaralı Televizyon", Price=6000,Stock=50,IsApproved=true,CategoryId=3, Image="3.jpg", IsHome=true},
                new Product(){Name="Philips Tv",Description="2 numaralı Televizyon", Price=7999,Stock=50,IsApproved=true,CategoryId=3, Image="3.jpg"},


                new Product(){Name="Samsung Telefon",Description="1 numaralı Telefon", Price=3500,Stock=50,IsApproved=true,CategoryId=4, Image="4.jpg", IsHome=true},
                new Product(){Name="Iphone Telefon",Description="2 numaralı Telefon", Price=6500,Stock=50,IsApproved=true,CategoryId=4, Image="4.jpg"},

            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}