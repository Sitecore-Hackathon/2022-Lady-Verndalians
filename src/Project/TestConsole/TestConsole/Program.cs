using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace TestConsole
{
    public class Program
    {
        public static async Task FromFile(SpeechConfig speechConfig)
        {
            var audioConfig = AudioConfig.FromWavFileInput("c:\\tmp\\d9246746-3646-4bd6-84a7-5b7bd98e16e1.wav");
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine($"RECOGNIZED: Text={result.Text}");
        }

        public static async Task<string> FromStream(SpeechConfig speechConfig)
        {
            StringBuilder resultStringBuilder = new StringBuilder();
            //var reader = new BinaryReader(File.OpenRead("c:\\tmp\\d9246746-3646-4bd6-84a7-5b7bd98e16e1.wav"));
            //var audioInputStream = AudioInputStream.CreatePushStream();
            //var audioConfig = AudioConfig.FromStreamInput(audioInputStream);
            //var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var audioConfig = AudioConfig.FromWavFileInput("c:\\tmp\\d9246746-3646-4bd6-84a7-5b7bd98e16e1.wav");
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var stopRecognition = new TaskCompletionSource<int>();

            recognizer.Recognizing += (s, e) =>
            {
                Console.WriteLine($"RECOGNIZING: {e.Result.Text}");
            };

            recognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    //Console.WriteLine($"RECOGNIZED: {e.Result.Text}");

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
                Console.WriteLine("\n    ***COMPLETE***");
                stopRecognition.TrySetResult(0);
            };

            await recognizer.StartContinuousRecognitionAsync();

            // Waits for completion. Use Task.WaitAny to keep the task rooted.
            Task.WaitAny(new[] { stopRecognition.Task },120000);

            await recognizer.StopContinuousRecognitionAsync();

            //var result = await recognizer.RecognizeOnceAsync();
            //Console.WriteLine($"RECOGNIZED: Text={result.Text}");

            Console.WriteLine(resultStringBuilder.ToString());
            Console.ReadLine();

            return resultStringBuilder.ToString();
        }


        public static async Task Main(string[] args)
        {
            var speechConfig = SpeechConfig.FromSubscription("22c9d4042aaa4a68b05c5694c1e98623", "westus");
            
            await FromStream(speechConfig);
             
        }
    }
}
