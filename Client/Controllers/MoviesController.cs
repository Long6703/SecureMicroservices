using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client.Model;
using Client.APIServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Client.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMoviesAPIService _moviesAPIService;

        public MoviesController(IMoviesAPIService moviesAPIService)
        {
            _moviesAPIService = moviesAPIService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _moviesAPIService.GetMovies());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Movies == null)

            //{
            //    return NotFound();
            //}

            //var movies = await _context.Movies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movies == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movies movies)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(movies);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movies = await _context.Movies.FindAsync(id);
            //if (movies == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movies movies)
        {
            if (id != movies.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(movies);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MoviesExists(movies.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(movies);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movies = await _context.Movies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movies == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Movies == null)
            //{
            //    return Problem("Entity set 'ClientContext.Movies'  is null.");
            //}
            //var movies = await _context.Movies.FindAsync(id);
            //if (movies != null)
            //{
            //    _context.Movies.Remove(movies);
            //}
            
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        private bool MoviesExists(int id)
        {
            //return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }

        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}
