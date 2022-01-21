using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entity
{
    public class Category
    {   //kategorinin Id'si
        public int Id { get; set; }
        //kategori içeriği
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:20, ErrorMessage ="En fazla 20 karakter girilebilir.")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        //tablo ilişkilendirmesi
        public List<Product> Products { get; set; }
    }
}