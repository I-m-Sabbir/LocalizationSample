using LocalizationPractice.Web.DbContexts;
using LocalizationPractice.Web.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocalizationPractice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(int id = 0)
        {
            var model = new PersonalInformation();

            try
            {
                if(id > 0)
                    model = _context.PersonalInformation.FirstOrDefault(x => x.EntityId == id);

                if (model == null)
                    throw new Exception("no information found");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Privacy(PersonalInformation model)
        {

            try
            {
                if(model.EntityId > 0)
                {
                    var dbModel = _context.PersonalInformation.FirstOrDefault(x =>x.EntityId == model.EntityId);
                    if (dbModel == null)
                        throw new Exception("no information found");

                    dbModel.Name = model.Name;
                    dbModel.Address = model.Address;
                }
                else
                {
                    _context.PersonalInformation.Add(model);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
