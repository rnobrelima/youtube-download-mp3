using MediaToolkit.Model;
using MediaToolkit;
using VideoLibrary;
using System.Diagnostics;

namespace youtube_download_mp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var source = @"D:\Nicole\";
            var youtube = YouTube.Default;
            
            List<string> videosList = new() 
            { 
              //"https://youtu.be/1V4WZcuDYiA", "https://youtu.be/ZPB1pSH-gYU","https://youtu.be/_IWyXyAzqfA","https://youtu.be/qVveeynmzok","https://youtu.be/Y82H_pgqKdY",
              "https://youtu.be/oXMRRcj5kNc", "https://youtu.be/GN47W9jyYUE","https://youtu.be/EQj1GzLkicU"
            };
            

            foreach (var video in videosList)
            {
                var timer = new Stopwatch();
                timer.Start();
                var vid = youtube.GetVideo(video);
                Console.WriteLine($"Iniciou o gravação da música em {source + vid.FullName}");
                File.WriteAllBytes(source + vid.FullName, vid.GetBytes());
                Console.WriteLine($"Finalizou o gravação da música em {source + vid.FullName}");
                var inputFile = new MediaFile { Filename = source + vid.FullName };
                var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    engine.Convert(inputFile, outputFile);
                }
                timer.Stop();
                Console.WriteLine($"tempo gasto: {timer.Elapsed.TotalSeconds}");

            }

        }

    }
}