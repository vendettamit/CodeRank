using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace CodeRank.CSharpProblems.Ruleset.Base
{
    /// <summary>
    /// Abstract class for all the sample rule tests
    /// </summary>
    [TestFixture]
    public class TestBase
    {
        /// <summary>
        /// Holds the instance of test domain.
        /// </summary>
        private AppDomain testDomain;

        /// <summary>
        /// The create domain and unwrap object.
        /// </summary>
        /// <param name="assemblyStream">
        /// The assembly stream.
        /// </param>
        /// <param name="typeName">
        /// The type Name.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object CreateDomainAndUnwrapObject(MemoryStream assemblyStream, string typeName)
        {
            string pathToDll = Assembly.GetExecutingAssembly().CodeBase;
            AppDomainSetup domainSetup = new AppDomainSetup { PrivateBinPath = pathToDll };
            this.testDomain = AppDomain.CreateDomain("TestDomain", null, domainSetup);
            return this.testDomain.CreateInstanceFromAndUnwrap(pathToDll, typeName);
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            GC.Collect(); // collects all unused memory
            GC.WaitForPendingFinalizers(); // wait until GC has finished its work
            GC.Collect();
        }

        /// <summary>
        /// The get instance of item under test.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        protected object GetInstanceOfItemUnderTest(string typeName)
        {
            Type targetType;

            foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {
                targetType = assem.GetTypes().FirstOrDefault(x => x.Name == typeName);
                if (targetType != null)
                {
                    return Activator.CreateInstance(targetType) as ISampleTest;
                }
            }

            return null;
        }
    }
}
