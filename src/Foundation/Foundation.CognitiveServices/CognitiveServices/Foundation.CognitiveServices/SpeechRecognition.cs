using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Foundation.CognitiveServices
{
    public static class SpeechRecognition
    {

        public static async Task<string> GetTranslatedText(string mp3Path, string license, string region)
        {
            var speechConfig = SpeechConfig.FromSubscription(license, region);

            var wavPath = "c:\\tmp\\d9246746-3646-4bd6-84a7-5b7bd98e16e1.wav";
            var translation = await FromStream(speechConfig, wavPath);

            return translation;
        }

        public static async Task<string> FromStream(SpeechConfig speechConfig, string wavPath)
        {
            StringBuilder resultStringBuilder = new StringBuilder();

            var audioConfig = AudioConfig.FromWavFileInput(wavPath);
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var stopRecognition = new TaskCompletionSource<int>();

            recognizer.Recognizing += (s, e) =>
            {
                Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
            };

            recognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");

                    resultStringBuilder.Append(e.Result.Text);
                }
                else if (e.Result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
            };

            recognizer.Canceled += (s, e) =>
            {
                Console.WriteLine($"CANCELED: Reason={e.Reason}");

                if (e.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you update the speech key and location/region info?");
                }

                stopRecognition.TrySetResult(0);
            };

            recognizer.SessionStopped += (s, e) =>
            {
                Console.WriteLine("\n    Session stopped event.");
                stopRecognition.TrySetResult(0);
            };

            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

            // Waits for completion. Use Task.WaitAny to keep the task rooted.
            Task.WaitAny(new[] { stopRecognition.Task }, 120000);

            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);

            //var result = await recognizer.RecognizeOnceAsync();
            //Console.WriteLine($"RECOGNIZED: Text={result.Text}");

            Console.WriteLine(resultStringBuilder.ToString());

            return resultStringBuilder.ToString();
        }
    }
}
