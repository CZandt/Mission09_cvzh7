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
        public string ReturnUrl { get; set; }

        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Basket basket { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);
            
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove()
        {

        }
    }
}
