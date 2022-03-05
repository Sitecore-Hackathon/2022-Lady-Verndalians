using System.Web.Mvc;
using Mvp.Feature.Media.Podcast.Models;
using Sitecore.Mvc.Controllers;

namespace Website.Controllers.Podcast
{
    public class PodcastController : SitecoreController
    {
        public ActionResult Podcast()
        {
            var podcastModel = new PodcastModel(Sitecore.Context.Item);
            return View("~/Views/Podcast/PodcastDetailPage.cshtml", podcastModel);
        }
    }
}