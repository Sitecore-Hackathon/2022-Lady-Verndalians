using System.Collections.Generic;
using System.Web.Mvc;
using Mvp.Feature.Media.Podcast.Models;
using Mvp.Feature.Search.Models;
using Mvp.Feature.Search.SearchRepositories;
using Sitecore.Mvc.Controllers;

namespace Website.Controllers.Podcast
{
    public class PodcastListController : SitecoreController
    {
        public ActionResult Podcasts()
        {
            var podcastModel = new PodcastListModel();

            return View("~/Views/Podcast/PodcastListPage.cshtml", new List<PodcastSearchResultItem>());
        }

        [HttpPost]
        public ActionResult Podcasts(string postphrase)
        {
            var query = Request.Form["phrase"];

            var podcastModel = new PodcastListModel();

            var searchRepo = new PodcastSearchRepository();
            
            return View("~/Views/Podcast/PodcastListPage.cshtml", searchRepo.GetPodcasts(query));
        }
    }
}