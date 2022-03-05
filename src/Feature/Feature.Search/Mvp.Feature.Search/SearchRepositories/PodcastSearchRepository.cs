using System.Collections.Generic;
using System.Linq;
using Mvp.Feature.Search.Models;
using Sitecore.ContentSearch;

namespace Mvp.Feature.Search.SearchRepositories
{
    public class PodcastSearchRepository
    {
        public IEnumerable<PodcastSearchResultItem> GetPodcasts(string query)
        {
            ISearchIndex index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                return context.GetQueryable<PodcastSearchResultItem>()
                    .Where(x => x.TemplateName == "Podcast Detail" 
                                && !x.Name.Contains("__") 
                                && x.PodcastTranscription.Contains(query));
            }
        }
    }
}
