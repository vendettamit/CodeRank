using System;
using System.Linq;
using System.Reflection;

using CodeRank.CSharpProblems.Ruleset.Base;

using NUnit.Framework;

namespace CodeRank.CSharpProblems.Ruleset
{
    /// <summary>
    /// Verifies the implementation of ISampleTest rule set.
    /// </summary>
    [TestFixture]
    public class SampleTest : TestBase
    {
        /// <summary>
        /// The object under test.
        /// </summary>
        private ISampleTest objectUnderTest;

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.objectUnderTest = this.GetInstanceOfItemUnderTest("SampleTestRuleSolution") as ISampleTest;
        }

        /// <summary>
        /// The sum_ supplied argumemtss_ gives correct result.
        /// </summary>
        [Test]
        [Description(("The sum operation with arg1 = 2 and arg2 = 3 must result in value 5."))]
        public void Sum_SuppliedArgumemtss_GivesCorrectResult()
        {
            Assert.AreEqual(5, this.objectUnderTest.Sum(2, 3), "Yielded result was no as expected. See description.");
        }
    }
}
