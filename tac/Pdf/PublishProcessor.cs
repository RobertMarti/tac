using System.Diagnostics.CodeAnalysis;
using Sitecore.Diagnostics;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace tac.Pdf
{
    /// <summary>
    /// Publish processor which creates and saves configured pages to EArchive.
    /// </summary>
    public class PublishProcessor : PublishItemProcessor
    {
        [SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
        public override void Process(PublishItemContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            var item = context.PublishHelper.GetSourceItem(context.ItemId);
            if (item == null) return;

            if (!this.IsItemConfiguredForArchive()) return;

            string pageUrl;
            string content;

            pageUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            var urlOptions = new Sitecore.Links.UrlBuilders.ItemUrlBuilderOptions() { AlwaysIncludeServerUrl = true };
            pageUrl = Sitecore.Links.LinkManager.GetItemUrl(item, urlOptions);

            pageUrl = Sitecore.Context.RawUrl;

            pageUrl = "https://tacsc.dev.local/?sc_database=master&sc_itemid={%7B1E02A992-DEC3-4040-A101-3148B4B74915%7D}";
            content = Sitecore.Web.WebUtil.ExecuteWebPage(pageUrl);
            ////PdfLibrary.SelectPdf.CreatePdfFile(pageUrl, "");

            // https://sitecore.stackexchange.com/questions/11187/how-do-you-programmatically-get-the-html-from-a-sitecore-item-including-all-its ?
        }

        // TODO: Make item configurable for authors
        private bool IsItemConfiguredForArchive()
        {
            return true;
        }
    }
}
