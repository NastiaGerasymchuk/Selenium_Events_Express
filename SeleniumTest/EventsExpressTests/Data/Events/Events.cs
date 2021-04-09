using SeleniumTest.EventsExpressTests.Enum;
using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections;
using System.Globalization;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    class Events:IEnumerable
    { 
            private Event todayEvent = new Event { 
                                                    Author="Admin",
                                                    Title= "This is Admin's Day Event",
                                                    Participants= "0/8",
                                                    Description= "Day event",
                                                    OnlineTitle= "Online meeting here",
                                                    OnlinePath= "https://www.c-sharpcorner.com/article/how-to-read-data-from-csv-file-in-c-sharp/%20;1",
                                                    Category= "#Golf",
                                                    DateFrom = GetStringDate(DateTime.Now),
                                                    DateTo = GetStringDate(DateTime.Now),
                                                    FullDate = GetFullDate(DateTime.Now,DateTime.Now),
                                                    HeaderVisitor="0",
                                                    Protection = Protection.Public,
                                                  };
            private Event weekEvent = new Event
            {
                Author = "User",
                Title = "This is User's Week Event",
                Participants = "0/8",
                Description = "Week event",
                OnlineTitle = "Online meeting here",
                OnlinePath = "https://www.c-sharpcorner.com/article/how-to-read-data-from-csv-file-in-c-sharp/%20;1",
                Category = "#Sea",
                DateFrom = GetStringDate(DateTime.Now.AddDays(1)),
                DateTo = GetStringDate(DateTime.Now.AddDays(8)),
                FullDate = GetFullDate(DateTime.Now.AddDays(1), DateTime.Now.AddDays(8)),
                HeaderVisitor = "0",
                Protection = Protection.Public,
            };
            private Event monthEvent = new Event
            {
                Author = "Admin",
                Title = "This is Admin's Month Event",
                Participants = "0/8",
                Description = "Month event",
                OnlineTitle = "Online meeting here",
                OnlinePath = "https://www.c-sharpcorner.com/article/how-to-read-data-from-csv-file-in-c-sharp/%20;1",
                Category = "#Sport",
                DateFrom = GetStringDate(NextMonth(DateTime.Now)),
                DateTo= GetStringDate(NextMonth(DateTime.Now.AddDays(7))),
                FullDate = GetFullDate(NextMonth(DateTime.Now), NextMonth(DateTime.Now.AddDays(7))),
                HeaderVisitor = "0",
                Protection = Protection.Public,
            };
        private static string GetStringDate(DateTime date)
        {
            return date.ToString("d MMM yyyy", DateTimeFormatInfo.InvariantInfo);
        }
        private static string GetFullDate(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom == dateTo)
            {
                return GetStringDate(dateFrom);
            }
            return $"{GetStringDate(dateFrom)}-{GetStringDate(dateTo)}";
        }
        public static DateTime NextMonth(DateTime date)
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
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { todayEvent,(int)EventOrder.First };
            yield return new object[] { weekEvent, (int)EventOrder.Second };
            yield return new object[] { monthEvent, (int)EventOrder.Third };
        }
    }
}
