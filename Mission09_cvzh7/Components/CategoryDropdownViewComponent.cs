using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_cvzh7.Models;
using Mission09_cvzh7.Models.ViewModels;

namespace Mission09_cvzh7.Components
{
    public class CategoryDropdownViewComponent : ViewComponent
    {
        private BooksViewModel Categories;
        private IBookstoreRepository repo;

        public CategoryDropdownViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            var Cats = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == "Classic" || "Classic" == null)
                .OrderBy(b => b.Title)
                .Skip(1 * (1 - 1))
                .Take(1),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Books.Count()
                },

                Categories = repo.Books
                .OrderBy(b => b.Category)


            };

            return View(Cats);
        }
    }
}
