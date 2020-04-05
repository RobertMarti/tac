using System.Web;

namespace tac.Models
{
    public class EventIntro
    {
        public HtmlString ContentHeading { get; set; }
        public HtmlString ContentIntro { get; set; }
        public HtmlString ContentBody { get; set; }
        public HtmlString EventImage { get; set; }
        public HtmlString Highlights { get; set; }
        public HtmlString StartDate { get; set; }
        public HtmlString Duration { get; set; }
        public HtmlString Difficulty { get; set; }
    }
}