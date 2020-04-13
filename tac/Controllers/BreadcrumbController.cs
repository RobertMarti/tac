using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using tac.Models;

namespace tac.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private IEnumerable<NavigationItem> CreateModel()
        {
            Item item = RenderingContext.Current.ContextItem;
            Item homeItem = Sitecore.Context.Database.GetItem("/sitecore/Content/Events/Home");

            IEnumerable<Item> breadcrumb = item.Axes.GetAncestors()
                .Where(i => i.Axes.IsDescendantOf(homeItem))
                .Concat(new Item[] { item });

            IEnumerable<NavigationItem> navigationItems = breadcrumb.Select(s => new NavigationItem
            {
                Title = s.DisplayName,
                Url = LinkManager.GetItemUrl(s),
                Active = (s.ID == item.ID)
            });

            return navigationItems;
        }
    }
}