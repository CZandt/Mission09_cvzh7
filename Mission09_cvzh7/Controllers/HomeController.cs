using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_cvzh7.Models;
using Mission09_cvzh7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp; // initializes the private repo from the temp object
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = 
                        (bookCategory == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                },

                Categories = repo.Books
                .OrderBy(b => b.Category)


            };
            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
