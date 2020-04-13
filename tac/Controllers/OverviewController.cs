using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using tac.Models;

namespace tac.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private OverviewList CreateModel()
        {
            var model = new OverviewList();
            model.AddRange(RenderingContext.Current.ContextItem.GetChildren()
                .Select(item => new OverviewItem()
                {
                    Url = LinkManager.GetItemUrl(item),
                    ContentHeading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                    DecorationBanner = new HtmlString(FieldRenderer.Render(item, "DecorationBanner", "mw=500&mh=333"))
                })
            );

            return model;
        }
    }
}