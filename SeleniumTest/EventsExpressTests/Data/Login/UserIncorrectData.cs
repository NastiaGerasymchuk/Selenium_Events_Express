using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
   public class UserIncorrectData:IEnumerable
    {
        private User user1 = new User { Email = "user1@gmail.com", Password = "1qaz1qaz" };
        private User user2 = new User { Email = "admin2@gmail.com", Password = "1qaz1qaz" };
        private User user3 = new User { Email = "admin@gmail.com", Password = "1qaz1qaz77" };
        private User user4 = new User { Email = "someData@gmail.com", Password = "88qaz1qaz77" };
        private User user5 = new User { Email = "user@gmail.com", Password = "1qaz1qaz3" };
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { user1 };
            yield return new object[] { user2 };
            yield return new object[] { user3 };
            yield return new object[] { user4 };
            yield return new object[] { user5 };
        }
    }
}
