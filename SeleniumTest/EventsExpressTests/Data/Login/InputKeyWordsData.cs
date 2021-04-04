using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Data
{
    class InputKeyWordsData:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //yield return new object[] {string.Empty};
            yield return new object[] { "some begining value" };
            yield return new object[] { "test input keyword" };
        }
    }
}
