using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelpyAdmin.Models;

namespace HelpyWeb6._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            // Save public images
            if (model.PublicImages != null)
            {
                foreach (var file in model.PublicImages)
                {
                    var filePath = Path.Combine("wwwroot/uploads/public", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            // Save private images
            if (model.PrivateImages != null)
            {
                foreach (var file in model.PrivateImages)
                {
                    var filePath = Path.Combine("wwwroot/uploads/private", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            // Process the rest of the form data
            // Save model properties like Age, Birthday, etc., to the database

            return Json(new { success = true, message = "Registration successful" });
        }
    }
}
