

using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Mvp.Feature.Search.Models
{
    public class PodcastSearchResultItem : SearchResultItem
    {
        [IndexField("podcast_name_t")]
        public string PodcastName { get; set; }

        [IndexField("transcription_t")]
        public string PodcastTranscription { get; set; }

        [IndexField("audio_file_path_t")]
        public string AudioFile { get; set; }
    }
}
