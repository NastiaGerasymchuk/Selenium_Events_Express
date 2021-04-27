using SeleniumTest.EventsExpressTests.Enum;
using System.Collections;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    public class EventsFilterKeyword:IEnumerable
    {
        public static  int AdminEventsCount = 2;
        public static int UserEventsCount = 1;
        public static int DayCount = 1;
        public static int WeekCount = 1;
        public static int MonthCount = 1;
        public static int YearCount = 1;
        private string GetStringFromEnum(EventPeriod eventPeriod)
        {
            return eventPeriod.ToString("g");
        }
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "Admin", UserEventsCount };
            yield return new object[] { "Admin", AdminEventsCount };
            yield return new object[] { GetStringFromEnum(EventPeriod.Day), DayCount };
            yield return new object[] { GetStringFromEnum(EventPeriod.Week), WeekCount };
            yield return new object[] { GetStringFromEnum(EventPeriod.Month), MonthCount };
            yield return new object[] { GetStringFromEnum(EventPeriod.Year), YearCount };
        }
    }
}
