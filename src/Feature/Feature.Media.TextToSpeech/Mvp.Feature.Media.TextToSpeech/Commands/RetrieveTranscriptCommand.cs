using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using System.Linq;

namespace Mvp.Feature.Media.TextToSpeech.Commands
{
    public class RetrieveTranscriptCommand : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.IsNotNull(context, "context");

            var contextItem = context.Items.FirstOrDefault();

            if (contextItem == null)
                return;

            //call to get transcription

            using (new EditContext(contextItem))
            {
                contextItem.Fields["Transcription"].Value =
                    "You've made a test transcription on: " + System.DateTime.Now.ToString("F");
            }
        }
    }
}
