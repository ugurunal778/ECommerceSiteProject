using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO.Models
{
    public class Cart
    {
        private List<CartLine> _cardlines = new List<CartLine>();
        public List<CartLine> Cardlines
        {
            get { return _cardlines; }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _cardlines.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line==null)
            {
                _cardlines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cardlines.RemoveAll(x => x.Product.Id == product.Id);
        }

        public double Total()
        {
            return _cardlines.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            _cardlines.Clear();
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}