using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
    public class NotCorrectEmailFull:IEnumerable
    {
        private User user1 = new User { Email = "user", Password = "1qaz1qaz" };
        private User user2 = new User { Email = "admin", Password = "1qaz1qaz" };
        private User user3 = new User { Email = "788", Password = "1qaz1qaz77" };
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { user1 };
            yield return new object[] { user2 };
            yield return new object[] { user3 };
        }
    }
}
