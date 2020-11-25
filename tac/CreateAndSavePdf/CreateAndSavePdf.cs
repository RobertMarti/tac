using Sitecore.Diagnostics;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace tac.CreateAndSavePdf
{
    /// <summary>
    /// Publish processor which creates and saves configured pages to EArchive.
    /// </summary>
    public class CreateAndSavePdf : PublishItemProcessor
    {
        public override void Process(PublishItemContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            var item = context.PublishHelper.GetSourceItem(context.ItemId);
            if (item == null) return;

            if (!this.IsItemConfiguredForArchive()) return;

            var url = Sitecore.Links.LinkManager.GetItemUrl(item);

            // https://sitecore.stackexchange.com/questions/11187/how-do-you-programmatically-get-the-html-from-a-sitecore-item-including-all-its ?
            var content = Sitecore.Web.WebUtil.ExecuteWebPage(url);
        }

        // TODO: Make item configurable for authors
        private bool IsItemConfiguredForArchive()
        {
            return true;
        }
    }
}
