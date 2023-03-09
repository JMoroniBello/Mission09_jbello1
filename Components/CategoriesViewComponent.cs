using Microsoft.AspNetCore.Mvc;
using Mission09_jbello1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jbello1.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository Repo { get; set; }

        public CategoriesViewComponent (IBookstoreRepository temp)
        {
            Repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = Repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}
