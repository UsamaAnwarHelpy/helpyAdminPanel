using HelpyAdmin.Data;
using HelpyAdmin.Models;
using HelpyAdmin.Repository.Interface;
using HelpyWebApi.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelpyAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<Users> signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IBills _billsRepository;
        private readonly HelpyDbContext _context;
        public HomeController(ILogger<HomeController> logger, IBills billsRepository, IUserRepository repository, HelpyDbContext context)
        {
            _logger = logger;
            _billsRepository = billsRepository;
            _userRepository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            ViewData["users"] = users;
            var bills = _context.Bills.ToList();
            ViewData["Bills"] = bills;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
