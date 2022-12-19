using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM1670.Data;
using ASM1670.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASM1670.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View(context.Authors.ToList());
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult Delete(int id)
        {
            var author = context.Authors.Find(id);
            context.Authors.Remove(author);
            context.SaveChanges();
            TempData["Message"] = "Delete author successfully !";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var author = context.Authors.Include(c => c.Book)
                                             .FirstOrDefault(c => c.Id == id);
            return View(author);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                context.Authors.Add(author);
                context.SaveChanges();
                TempData["Message"] = "Add author successfully !";
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            return View(author);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                context.Authors.Update(author);
                context.SaveChanges();
                TempData["Message"] = "Edit author successfully !";
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
    }
}
