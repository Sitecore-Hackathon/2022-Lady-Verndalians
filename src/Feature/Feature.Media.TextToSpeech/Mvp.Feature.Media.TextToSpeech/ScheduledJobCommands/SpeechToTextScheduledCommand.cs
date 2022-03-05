using Sitecore.Data.Items;

namespace Mvp.Feature.Media.TextToSpeech.ScheduledJobCommands
{
    public class SpeechToTextScheduledCommand
    {
        public void Execute(Item[] items, Sitecore.Tasks.CommandItem command, Sitecore.Tasks.ScheduleItem schedule)
        {
            Sitecore.Diagnostics.Log.Info("My Sitecore scheduled task is being run!", this);
        }
    }
}
