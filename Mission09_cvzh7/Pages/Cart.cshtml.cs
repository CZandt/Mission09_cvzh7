using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_cvzh7.Infrastructure;
using Mission09_cvzh7.Models;

namespace Mission09_cvzh7.Pages
{
    public class CartModel : PageModel
    {

        private IBookstoreRepository repo { get; set; }

        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Basket basket { get; set; }

        public void OnGet(Basket b)
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);
            
            return RedirectToPage();
        }
    }
}
