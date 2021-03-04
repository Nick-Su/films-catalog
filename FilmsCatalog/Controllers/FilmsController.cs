using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using FilmsCatalog.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FilmsCatalog.Data;


namespace FilmsCatalog.Controllers
{
    public class FilmsController : Controller
    {
        private readonly MobileContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _applicationDbContext;

        public FilmsController(MobileContext context, IWebHostEnvironment hostEnvironment, ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        // GET: Films
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 2;
            IQueryable<Film> source = _context.Films;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Films = items
            };

            ViewBag.uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(FilmViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Film film = new Film
                {
                    Title = model.Title,
                    Description = model.Description,
                    Year = model.Year,
                    Director = model.Director,
                    Poster = uniqueFileName,
                };
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(FilmViewModel model)
        {
            string uniqueFileName = null;

            if (model.Poster != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Posters");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Poster.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Poster.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var film = await _context.Films.FindAsync(id);
            var film = await _context.Films.FirstOrDefaultAsync(n => n.Id == id);


            IQueryable<Film> source = _context.Films;
            var items = await source.Where(n => n.Id == id).FirstOrDefaultAsync();

            FilmViewModel viewModel = new FilmViewModel
            {
                //Poster = items.Poster
                Id = film.Id,
                Title = film.Title,
                Description = film.Description,
                Year = film.Year,
                Director = film.Director,
                Poster = null
            };


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (film == null || film.AddedByUserId != userId)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Year,Director, Poster")] FilmViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = UploadedFile(model);

                    var entity = _context.Films.FirstOrDefault(x => x.Id == id);
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    if (entity != null && entity.AddedByUserId == userId)
                    {
                        entity.Title = model.Title;
                        entity.Description = model.Description;
                        entity.Year = model.Year;
                        entity.Director = model.Director;
                        entity.Poster = uniqueFileName;               
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} exception caught.", e);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }
           // var user = await _applicationDbContext.Users.FindAsync(film.AddedByUserId);

            // var userName = User.Identity. .FindFirstValue(ClaimTypes.Name); // email
            var addedByUser = await _userManager.FindByIdAsync(film.AddedByUserId);
            var userName = addedByUser.FirstName + " " + addedByUser.LastName;
            ViewBag.uname = userName;
            return View(film);
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
