using System.Collections.Generic;
using System.Linq;
using Mvp.Feature.Search.Models;
using Sitecore.ContentSearch;

namespace Mvp.Feature.Search.SearchRepositories
{
    public class PodcastSearchRepository
    {
        public List<PodcastSearchResultItem> GetPodcasts(string query)
        {
            List<PodcastSearchResultItem> podcastList;

            ISearchIndex index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                var list = context.GetQueryable<PodcastSearchResultItem>()
                    .Where(x => x.TemplateName == "Podcast Detail" 
                                && !x.Name.Contains("__") 
                                && (x.PodcastTranscription.Contains(query) || x.PodcastName.Contains(query)));

                podcastList = list.ToList();
            }

            return podcastList;
        }
    }
}
