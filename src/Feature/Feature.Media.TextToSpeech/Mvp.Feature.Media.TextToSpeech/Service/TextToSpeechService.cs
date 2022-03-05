using System;
using System.Threading.Tasks;
using Foundation.CognitiveServices;
using Mvp.Feature.Media.TextToSpeech.ScheduledJobCommands;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Jobs;

namespace Mvp.Feature.Media.TextToSpeech.Service
{
    public class TextToSpeechService
    {
        private Item _item;

        public void StartBackgroundJob(Item item)
        {
            if (item == null) return;

            _item = item;

            Item[] itemArray = {item};

            var speechToTextScheduledCommand = new SpeechToTextScheduledCommand();

            var jobName = "Transcribe Audio File - " + item.Name;
            var jobCategory = typeof(TextToSpeechService).Name;
            var siteName = Context.Site == null ? "No Site Context" : Context.Site.Name;
            var jobOptions = new DefaultJobOptions(jobName, jobCategory, siteName, this, nameof(Run));
            JobManager.Start(jobOptions);
        }

        public async Task Run()
        {
            try
            {
                var mp3File = _item.Fields["Audio File Path"].Value;
                var transcript = await SpeechRecognition.GetTranslatedText(mp3File).ConfigureAwait(false);

                using (new EditContext(_item))
                {
                    _item.Fields["Transcription"].Value = transcript;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
