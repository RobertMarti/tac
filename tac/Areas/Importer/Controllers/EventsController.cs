using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using tac.Areas.Importer.Models;

namespace tac.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {
            SaveEvents(file, parentPath);

            return View("Confirmation");
        }

        private void SaveEvents(HttpPostedFileBase file, string parentPath)
        {
            Database database = Sitecore.Configuration.Factory.GetDatabase("master");
            Item parentItem = database.GetItem(parentPath);
            TemplateID templateId = new TemplateID(new ID("{372F0C56-2CCF-4352-A479-5CFE8ECE91E7}"));
            using (new SecurityDisabler())
            {
                foreach (var ev in GetEvents(file))
                {
                    string name = ItemUtil.ProposeValidItemName(ev.Name);

                    //if event exists then edit event else add event
                    var item = parentItem.GetChildren().FirstOrDefault(x => x.Name == name);
                    if (item == null)
                    {
                        item = parentItem.Add(name, templateId);
                    }

                    if (item != null)
                    {
                        item.Editing.BeginEdit();

                        //assign values for all the fields, for example for ContentHeading:
                        item["Name"] = ev.Name;
                        item["ContentHeading"] = ev.ContentHeading;
                        item["ContentIntro"] = ev.ContentIntro;
                        item["Highlights"] = ev.Highlights;
                        item["StartDate"] = Sitecore.DateUtil.ToIsoDate(ev.StartDate);
                        item["Duration"] = ev.Duration.ToString();
                        item["Difficulty"] = ev.Difficulty.ToString();

                        item.Editing.EndEdit();
                    }
                }
            }
        }

        private IEnumerable<Event> GetEvents(HttpPostedFileBase file)
        {
            IEnumerable<Event> events;
            using (var reader = new StreamReader(file.InputStream))
            {
                var contents = reader.ReadToEnd();
                try
                {
                    events = JsonConvert.DeserializeObject<IEnumerable<Event>>(contents);
                }
                catch
                {
                    events = null;
                }
            }

            return events;
        }
    }
}