using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using tac.Models;

namespace tac.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private IEnumerable<NavigationItem> CreateModel()
        {
            var item = RenderingContext.Current.ContextItem;
            MultilistField relatedEvents = item.Fields["RelatedEvents"];
            var events = relatedEvents.GetItems()
                .Select(i => new NavigationItem()
                {
                    Title = i.DisplayName,
                    Url = LinkManager.GetItemUrl(i)
                });

            return events;
        }
    }
}