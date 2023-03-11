using Microsoft.AspNetCore.Mvc;
using Mission09_cvzh7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }

        public CheckoutController(ICheckoutRepository temp, Basket b)
        {
            basket = b;
            repo = temp;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.saveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
