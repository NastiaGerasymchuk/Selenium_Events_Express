using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
    class NotCorrectEmailEmptyPassword : IEnumerable
    {
        private User user1 = new User { Email = "user", Password = string.Empty };
        private User user2 = new User { Email = "admin", Password = string.Empty };
        private User user3 = new User { Email = "788", Password = string.Empty };
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { user1 };
            yield return new object[] { user2 };
            yield return new object[] { user3 };
        }
    }
}
