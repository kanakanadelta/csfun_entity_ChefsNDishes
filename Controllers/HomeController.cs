using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private CNDContext dbContext;

        public HomeController(CNDContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext
                .Chefs
                .Include(chef => chef.CreatedDishes)
                .ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        public IActionResult DishesView()
        {
            List<Dish> AllDishes = dbContext
                .Dishes
                .Include(dish => dish.Creator)
                .ToList();
            ViewBag.Dishes = AllDishes;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // NEW CONTROLS
        [HttpGet("newChef")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpGet("newDish")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext
                .Chefs
                .ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        // CREATE CONTROLS

        [HttpPost("createChef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            return View("NewChef");
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish newDish, int creatorId)
        {
            Chef creator = dbContext.Chefs.FirstOrDefault(chef => chef.ChefId == creatorId);
            newDish.Creator = creator;
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("DishesView");
            }
            return View("NewDish");
        }
    }
}
