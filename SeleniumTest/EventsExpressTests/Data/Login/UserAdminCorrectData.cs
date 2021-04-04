using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
    class UserAdminCorrectData : IEnumerable
    {
        private User user = new User { Email = "user@gmail.com", Password = "1qaz1qaz" };
        private User admin = new User { Email = "admin@gmail.com", Password = "1qaz1qaz" };
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { user};
            yield return new object[] { admin };
        }
    }
}
