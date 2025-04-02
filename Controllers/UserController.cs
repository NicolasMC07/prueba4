using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.Interface;
using Test.Models;

namespace Test.Controllers
{
    public class UserController(IUserServices userServices) : Controller
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<IActionResult> Index()
        {
            var users = await _userServices.GetAllUsers();
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [HttpGet] // Añade explícitamente el atributo HttpGet
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,OtherProperties")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userServices.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        [HttpGet] // Añade explícitamente el atributo HttpGet
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,OtherProperties")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userServices.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        // GET: User/Delete/5
        [HttpGet] // Añade explícitamente el atributo HttpGet
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user != null)
            {
                await _userServices.DeleteUser(user);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}