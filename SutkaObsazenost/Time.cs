using System;

namespace SutkaObsazenost
{
    internal static class Time
    {
        private static TimeSpan openingPoolWorkDay = new TimeSpan(6, 0, 0);
        private static TimeSpan openingAquaparkWorkDay = new TimeSpan(14, 0, 0);
        private static TimeSpan closingWorkDay = new TimeSpan(22, 0, 59);

        private static TimeSpan openingWeekend = new TimeSpan(10, 0, 0);
        private static TimeSpan closingWeekend = new TimeSpan(22, 0, 59);

        public static bool IsPoolOpened
        {
            get { return IsOpened(openingPoolWorkDay, closingWorkDay, openingWeekend, closingWeekend); }
        }

        public static bool IsAquaparkOpened
        {
            get { return IsOpened(openingAquaparkWorkDay, closingWorkDay, openingWeekend, closingWeekend); }
        }

        private static bool IsOpened(TimeSpan openWork, TimeSpan closeWork, TimeSpan openWeekend, TimeSpan closeWeekend)
        {
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                    default:
                        return DateTime.Now.TimeOfDay >= openWork && DateTime.Now.TimeOfDay <= closeWork;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        return DateTime.Now.TimeOfDay >= openWeekend && DateTime.Now.TimeOfDay <= closeWeekend;
                }
        }

        public static TimeSpan StartAfter(TimeSpan interval)
        {
            double totalSecs = DateTime.Now.TimeOfDay.TotalSeconds;
            double intervalSecs = interval.TotalSeconds;
            TimeSpan elapsedFromInterval = TimeSpan.FromSeconds(totalSecs % intervalSecs);
            return interval - elapsedFromInterval;
        }

        private static int ToWait(int now, int interval)
        {
            int toWait = 0;
            if (interval > 0)
            {
                toWait = interval - (now % interval);
            }
            return toWait;
        }
    }
}
