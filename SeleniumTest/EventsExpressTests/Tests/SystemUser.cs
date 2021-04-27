using NUnit.Framework;
using SeleniumTest.EventsExpressTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Tests
{
    class SystemUser:BaseTest
    {
        private HomeEvent home;
        [SetUp]
        public override void SetUp()
        {
            
            base.SetUp();
            home = GetHomeObject();
        }
    
        [Test]
        public void ImpossibilityCreateEvent()
        {           
            Assert.That(home.IsHomeObject, Is.True);
        }
        [Test]
        [Obsolete]
        public void AdminPossibility()
        {
            UserAdminPage userAdminPage = home.Login(BaseInfoData.Admin);
            Assert.That(userAdminPage.IsAdminPage, Is.True);
        }
        [Test]
        [Obsolete]
        public void UserPossibility()
        {
            UserAdminPage userAdminPage = home.Login(BaseInfoData.User);
            Assert.That(userAdminPage.IsUserPage, Is.True);
        }
        public override void TearDown()
        {
           base.TearDown();
        }

    }
}
