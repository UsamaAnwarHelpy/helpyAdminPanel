using HelpyAdmin.Data;
using HelpyAdmin.Models;
using HelpyAdmin.Repository.Interface;
using HelpyWebApi.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpyAdmin.Controllers
{
    public class BillController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<Users> signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IBills _billsRepository;
        private readonly HelpyDbContext _context;

        public BillController(ILogger<HomeController> logger, IBills billsRepository, IUserRepository repository, HelpyDbContext context)
        {
            _logger = logger;
            _billsRepository = billsRepository;
            _userRepository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            var bills = _context.Bills.ToList();
            ViewData["Bills"] = bills;
            return View();
        }

        public async Task AddBill(string name, bool isActive)
        {
            var bill = new Bills()
            {
                Name = name,
                IsActive = isActive,
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }
    }
}
