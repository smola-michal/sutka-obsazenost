using System;
using System.Collections.Generic;
using System.IO;

namespace SutkaObsazenost
{
    public static class Storage
    {
        private static string poolFileName = "C:\\Users\\msmola\\OneDrive\\bazen.txt";
        private static string aquaparkFileName = "C:\\Users\\msmola\\OneDrive\\aquapark.txt";
        private static string logFileName = "C:\\Users\\msmola\\Desktop\\sutkaLog.txt";

        public static void AddValues(Tuple<int, int> values)
        {
            RecordEvent("Adding values to storage");
            AddPoolValue(values.Item1);
            AddAquaparkValue(values.Item2);
        }

        public static void AddPoolValue(int value)
        {
            if (Time.IsPoolOpened)
            {
                File.AppendAllLines(poolFileName, new List<string>() { $"{DateTime.Now.ToShortDateString()}, {DateTime.Now.ToShortTimeString()}, {value}" });
            }
        }

        public static void AddAquaparkValue(int value)
        {
            if (Time.IsAquaparkOpened)
            {
                File.AppendAllLines(aquaparkFileName, new List<string>() { $"{DateTime.Now.ToShortDateString()}, {DateTime.Now.ToShortTimeString()}, {value}" });
            }
        }

        public static void RecordEvent(string message)
        {
#if DEBUG
            RecordMessage(new List<string>() { message });
#endif
        }

        public static void RecordError(Exception exception)
        {
            RecordError(ListFromException(exception));
            if (exception.InnerException != null)
            {
                RecordError(ListFromException(exception.InnerException, "Inner exception:"));
            }
        }

        public static void RecordError(List<string> errorMessage)
        {
            errorMessage.Insert(0, "*********************************************ERROR*********************************************");
            RecordMessage(errorMessage);
        }

        private static void RecordMessage(List<string> message)
        {
            message.Insert(0, DateTime.Now.ToString());
            File.AppendAllLines(logFileName, message);
        }

        private static List<string> ListFromException(Exception ex, string header = "")
        {
            var result = new List<string>() { "Message:", ex.Message, "Stack trace:", ex.StackTrace, string.Empty };
            if(!string.IsNullOrEmpty(header))
            {
                result.Insert(0, header);
            }
            return result;
        }
    }
}
