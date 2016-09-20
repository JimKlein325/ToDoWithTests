using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class SuggestionsController : Controller
    {
        private ISuggestionRepository repo;

        public SuggestionsController(ISuggestionRepository repository)
        {
            repo = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(repo.AllSuggestions.ToList());
        }
        [HttpPost]
        public IActionResult AddSuggestion(string newCity, string newCountry, string newDescription)
        {
            Suggestion newDestination = new Suggestion(newCity, newCountry, newDescription);
            repo.Add(newDestination);
            return Json(repo.AllSuggestions);
        }

    }
}
