using Sitecore.Data.Items;

namespace Mvp.Feature.Media.Podcast.Models
{
    public class PodcastModel
    {
        public Item PodcastItem { get; private set; }

        public PodcastModel(Item item)
        {
            PodcastItem = item;
        }

        public string PodcastName
        {
            get
            {
                if (!string.IsNullOrEmpty(PodcastItem["Podcast Name"]))
                {
                    return PodcastItem["Podcast Name"];
                }

                return string.Empty;
            }
        }

        public string PodcastAudioFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(PodcastItem["Audio File Path"]))
                {
                    return PodcastItem["Audio File Path"];
                }

                return string.Empty;
            }
        }

        public string PodcastTranscript
        {
            get
            {
                if (!string.IsNullOrEmpty(PodcastItem["Transcript"]))
                {
                    return PodcastItem["Transcript"];
                }

                return string.Empty;
            }
        }
    }
}
