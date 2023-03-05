using Microsoft.AspNetCore.Mvc;
using Mission09_cvzh7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CategoryViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
