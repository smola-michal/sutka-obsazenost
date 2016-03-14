using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SutkaObsazenost
{
    public static class SutkaPage
    {
        private static string sutkaWebAddress = "http://www.sutka.eu/";

        public static Tuple<int,int> ObsazenostBazenAquapark()
        {
            Storage.RecordEvent("ObsazenostBazenAquapark requested");
            string textBeforePoolCount = "Aktuální počet návštěvníků:";
            string textAfterPoolCount = "(Bazén)";
            string textBeforeAquaparkCount = "(Bazén),";
            string textAfterAquaparkCount = "(Aquapark)";

            string source = PageSource;
            int bazen = Obsazenost(source, textBeforePoolCount, textAfterPoolCount);
            int aquapark = Obsazenost(source, textBeforeAquaparkCount, textAfterAquaparkCount);
            Storage.RecordEvent("ObsazenostBazenAquapark delivered");
            return new Tuple<int, int>(bazen, aquapark);
        }

        private static string PageSource
        {
            get
            {
                Storage.RecordEvent("PageSource requested");
                using (HttpClient client = new HttpClient())
                {
                    Task<string> sourceTask = client.GetStringAsync(sutkaWebAddress);
                    if (sourceTask.IsFaulted || sourceTask.IsCanceled)
                    {
                        Storage.RecordError(sourceTask.Exception);
                        return string.Empty;
                    }
                    Storage.RecordEvent("PageSource delivered");
                    return sourceTask.Result;
                }
            }
        }

        private static int Obsazenost(string pageSource, string textBefore, string textAfter)
        {
            Storage.RecordEvent("Obsazenost requested");
            int startIndex = pageSource.IndexOf(textBefore) + textBefore.Length;
            int endIndex = pageSource.IndexOf(textAfter);
            if (0 < startIndex && startIndex < endIndex)
            {
                string resultString = pageSource.Substring(startIndex, endIndex - startIndex);
                int result;
                if (int.TryParse(resultString, out result))
                {
                    Storage.RecordEvent("Obsazenost delivered");
                    return result;
                }
            }
            Storage.RecordEvent("Obsazenost cannot be delivered");
            return -1;
        }
    }
}
