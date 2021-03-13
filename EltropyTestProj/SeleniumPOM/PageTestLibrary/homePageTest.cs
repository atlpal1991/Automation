using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeleniumPOM
{
    [TestFixture]
    class homePageTest : BaseTest
    {

        [Test]
        public void SearchFlight()
        {

            HomePage p1 = new HomePage();
            p1.testmethod();

        }
    }
}
