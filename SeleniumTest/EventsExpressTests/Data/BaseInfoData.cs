using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SeleniumTest.EventsExpressTests.Data
{
    public class BaseInfoData
    {
        public static string Today { get; } = DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo);
        public static User User { get; } = new User { Email = "admin@gmail.com", Password = "1qaz1qaz" };
        public static List<string> HomeMenu { get; } = new List<string> { "Home" };
        public static List<string> AdminMenu { get; } = new List<string> { "Home","Profile","Search Users","Recurrent Events","Comuna","Categories", "UnitsOfMeasuring","Users" };
        public static List<string> UserMenu { get; } = new List<string> { "Home", "Profile", "Search Users", "Recurrent Events", "Comuna","Contact us" };
    }
}
