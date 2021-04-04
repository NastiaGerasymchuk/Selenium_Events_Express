using SeleniumTest.EventsExpressTests.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    
        public class EventsFilterCategory : IEnumerable
        {
            private const int GolfCount = 1;
            private const int SeaCount = 1;
            private const int SportCount = 1;
            private const int MountCount = 1;
            private string GetStringFromEnum(Category category)
            {
                return category.ToString("g");
            }
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { GetStringFromEnum(Category.Golf), GolfCount };
                yield return new object[] { GetStringFromEnum(Category.Sea), SeaCount };
                yield return new object[] { GetStringFromEnum(Category.Sport), SportCount };
                yield return new object[] { GetStringFromEnum(Category.Mount), MountCount };
            }
        
    }
}
