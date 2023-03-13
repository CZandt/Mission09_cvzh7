using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_cvzh7.Models;

namespace Mission09_cvzh7.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basketService;

        public CartSummaryViewComponent(Basket temp)
        {
            basketService = temp;
        }

        public IViewComponentResult Invoke()
        {
            return View(basketService);
        }
    }
}
