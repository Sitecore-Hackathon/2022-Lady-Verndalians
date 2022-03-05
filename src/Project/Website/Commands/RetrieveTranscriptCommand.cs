using System.Configuration;
using System.Linq;
using Mvp.Feature.Media.TextToSpeech.Service;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;

namespace Website.Commands
{
    public class RetrieveTranscriptCommand : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.IsNotNull(context, "context");

            var contextItem = context.Items.FirstOrDefault();

            if (contextItem == null)
                return;

            if (string.IsNullOrEmpty(contextItem.Fields["Audio File Path"]?.Value))
            {
                Context.ClientPage.ClientResponse.Alert($"Please populate the Audio File Path before attempting to transcribe.");
                return;
            }

            if (!contextItem.Fields["Audio File Path"].Value.EndsWith(".mp3"))
            {
                Context.ClientPage.ClientResponse.Alert($"At this time, the transcription process only supports mp3 files. Please populate the Audio File Path with an mp3.");
                return;
            }
            
            Context.ClientPage.ClientResponse.Alert($"Press OK to continue to the parent page.  Check back later to review transcription.");
            
            string load = "item:load(id={5AAAACF1-A454-44A5-9940-E9353D1A3521},language=en,version=1)";
            Context.ClientPage.ClientResponse.Timer(load, 0);

            var license = ConfigurationManager.AppSettings["CognitiveServicesLicenseKey"];
            var key = ConfigurationManager.AppSettings["CognitiveServicesRegion"];

            //call to get transcription
            var transcriptService = new TextToSpeechService(license, key);
            
            transcriptService.StartBackgroundJob(contextItem);
        }
    }
}
