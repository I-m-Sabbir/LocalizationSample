using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationPractice.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        [HttpPost]
        public IActionResult SetLanguage(string culturalInfoName, string url)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culturalInfoName)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

            return Redirect(url);
        }
    }
}
