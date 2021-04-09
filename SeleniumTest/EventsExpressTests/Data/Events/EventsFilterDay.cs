using System;
using System.Collections;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    public class EventsFilterDay : IEnumerable
    {
        private const int TodayDay = 0;
        private const int TomorrowDay = 1;
        private const int DayEventCount= 1;
        private const int TomorrowWeek = 1;
        private const int NextWeek = 8;
        private const int WeekEventCount = 1;


        public IEnumerator GetEnumerator()
        {
            yield return new object[] { TodayDay,TomorrowDay,DayEventCount };
            yield return new object[] { TomorrowWeek, NextWeek, WeekEventCount };

        }
        public  DateTime GetNextMonth(DateTime date)
        {
            DateTime nextMonth = date.AddMonths(1);

            if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
            {
                return nextMonth;
            }
            else
            {
                return date.AddDays(DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));
            }
        }
    }

}
