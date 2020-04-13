using System.Web;

namespace tac.Models
{
    public class OverviewItem
    {
        public HtmlString ContentHeading { get; set; }
        public HtmlString DecorationBanner { get; set; }
        public string Url { get; set; }
    }
}