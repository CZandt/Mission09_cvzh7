using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        
        public virtual void AddItem(Book bk, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book bk)
        {
            Items.RemoveAll(x => x.Book.BookId == bk.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public virtual double CalculateTotal()
        {
            // Calculates the sum price of all the items in the cart
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
