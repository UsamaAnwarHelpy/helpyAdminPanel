using HelpyAdmin.Data;
using HelpyAdmin.Models;
using HelpyAdmin.Repository.Interface;
using HelpyWebApi.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpyAdmin.Controllers
{
    public class Dashboard : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IBills _billsRepository;

        public Dashboard(IBills billsRepository, IUserRepository repository)
        {
            _billsRepository = billsRepository;
            _userRepository = repository;
        }
        public IActionResult Index()
        {
            var bills = _billsRepository.GetAllBills();
            return View(bills);
        }
    }
}
