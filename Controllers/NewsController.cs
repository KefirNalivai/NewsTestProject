using System;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    public class NewsController : Controller
    {
		
        private readonly DataManager dataManager;

        public NewsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
			
			if (id != default)
            {
                return View("Show", dataManager.NewsItems.GetServiceItemById(id));
            }

            
            return View(dataManager.NewsItems.GetServiceItems());
        }

		public IActionResult SetLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(returnUrl);
		}
	}
}