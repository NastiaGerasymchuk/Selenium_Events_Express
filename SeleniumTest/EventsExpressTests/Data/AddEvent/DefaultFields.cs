using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data.AddEvent
{
    public class DefaultFields:IEnumerable
    {
        private string today = DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo);
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "admin@gmail.com","1qaz1qaz", today };
        }
    }
}
