using System.Collections.Generic;

namespace Mvp.Feature.Media.Podcast.Models
{
    public class PodcastListModel
    {
        public const string PodcastFolderId = "";

        public List<PodcastModel> Podcasts
        {
            get
            {
                var podcasts = new List<PodcastModel>();

                //var podcastFolderItem = Sitecore.Context.Database.GetItem(PodcastFolderId);
                //if (podcastFolderItem != null && podcastFolderItem.Children.Count > 0)
                //{
                //    foreach (Item item in podcastFolderItem.Children)
                //    {
                //        var podcast = new podcastModel(item);
                //        podcasts.Add(podcast);
                //    }
                //}


                return podcasts;
            }
        }
    }
}
