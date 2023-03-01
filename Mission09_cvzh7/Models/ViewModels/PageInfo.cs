using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Calculates how many pages we need
        public int TotalPages => (int)Math.Ceiling(((double)TotalNumProjects / BooksPerPage));
    }
}
