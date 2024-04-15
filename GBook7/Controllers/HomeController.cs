using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GBook.Repository;

namespace GBook.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }*/

        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            //var userContext = await _context.Messages.Include(p => p.User);
            var model = await repo.GetMessageList();
            return View(model);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            ViewData["Id_User"] = new SelectList(_context.Messages, "Id","Message","MessageDate","User.Name" );
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Message")] Messages mes)
        {
            try
            {               
                mes.MessageDate = DateOnly.FromDateTime(DateTime.Now);

                mes.UserId = int.Parse(HttpContext.Session.GetString("Id"));

                _context.Add(mes);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}