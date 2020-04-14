using System.Web.Mvc;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using tac.Models;

namespace tac.Controllers
{
    public class SubscribeFormController : Controller
    {
        // GET: SubscribeForm
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private SubscribeFormLabels CreateModel()
        {
            //var dataSourceItem = GetDatasourceItem();
            var dataSourceItem = Context.Database.GetItem("/sitecore/Content/Events/Labels/SubscribeFormLabels");

            return new SubscribeFormLabels
            {
                OurNextEvents = dataSourceItem.Fields["OurNextEvents"].Value,
                SubscribeToNewsletter = dataSourceItem.Fields["SubscribeToNewsletter"].Value
            };
        }

        public Item GetDatasourceItem()
        {
            var datasourceId = RenderingContext.Current.Rendering.DataSource;
            return ID.IsID(datasourceId) ? Context.Database.GetItem(datasourceId) : null;
        }

        [HttpPost]
        [TAC.Utils.Mvc.ValidateFormHandler]
        public ActionResult Index(string email)
        {
            return View("Confirmation");
        }
    }
}