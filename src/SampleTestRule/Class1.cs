using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Util.ProjectConverters;
using NUnit.Framework;
using NUnit;
namespace SampleTestRule
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestMethodWork_Nothing_JustRunIt()
        {
            Assert.Fail("Test failed. Booomm!!!");
        }
    }
}
