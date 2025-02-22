using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission6_Stuart.Models;

namespace Mission6_Stuart.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;

        // Corrected constructor for dependency injection
        public HomeController(MovieCollectionContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {
            return View();
        }






        public IActionResult GetToKnowJoel()
        {
            return View();
        }




        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Category
                .ToList();

            return View("AddMovie", new Collection());  // new Collection() creates a new row with a new ID
        }











        [HttpPost]
        public IActionResult AddMovie(Collection response)
        {


            if (ModelState.IsValid)
            {
                _context.Collection.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Category
                    .ToList();

                return View(response);
            }
        }













        public IActionResult ViewMovies()
        {
            var movie = _context.Collection
                .Include(x => x.Category)
                .ToList();

            return View(movie);
        }

















    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Collection
            .Include(x => x.Category)
            .SingleOrDefault(x => x.MovieId == id); // Retrieve the movie by id

        if (movie == null) // If the movie is not found, handle the null case
        {
            return NotFound(); // Or you can return another view or message
        }

        ViewBag.Categories = _context.Category.ToList();  // Pass categories to the view

        return View("AddMovie", movie); // Open the AddMovie view with the movie's info
    }




        [HttpPost]
        public IActionResult Edit(Collection updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);  // Update the movie in the database
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");  // Redirect to ViewMovies after editing
            }
            ViewBag.Categories = _context.Category.ToList();  // Re-populate categories
            return View("AddMovie", updatedInfo);  // Return to AddMovie view with updated info
        }
















        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Collection
                .Single(x => x.MovieId == id);
            return View(movie);
        }



        [HttpPost]
        public IActionResult Delete(Collection movie)
        {
            _context.Collection.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }






    }


}
