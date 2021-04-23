using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
    public struct BaseData
    {
        public const string Uri = "https://localhost:44344/home/events?page=1&status=active";
        public const string ChromeDriver = @"C:\Users\Admin\source\repos";
        //@"C:\Users\Admin\Desktop";
        public const string FallTestFolder = @"C:\Users\Admin\source\repos\SeleniumTest\Screen\";
        public const int SecondsWaintings = 10;
        public const int EventsCount = 3;
        public const int ThreadSleep = 500;
    }
}
