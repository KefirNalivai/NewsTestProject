using System.Configuration;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using System.Net;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Xml.Linq;

namespace MyCompany.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
			
			return Task.FromResult((IViewComponentResult)View("Default", dataManager.NewsItems.GetLastServiceItems(1)));

        }


    }
}
