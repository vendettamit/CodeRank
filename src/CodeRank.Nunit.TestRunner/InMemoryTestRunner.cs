using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

using CodeRank.Api.Entities;
using CodeRank.Compiler.Base;

using NUnit.Engine;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Filters;

using InternalTraceLevel = NUnit.Engine.InternalTraceLevel;
using TestListener = NUnit.Framework.Internal.TestListener;
using TestResult = CodeRank.Api.Entities.TestResult;

namespace CodeRank.Nunit.TestRunner
{
    /// <summary>
    /// Runs the test of against given assembly and provides the formatted test result.
    /// Note: Call CoreExtensions.Host.InstallBuiltins(); where the runner has to be called.
    /// </summary>
    public class InMemoryNunitTestRunner : ICustomTestRunner
    {
        /// <summary>
        /// The schema file.
        /// </summary>
        private static readonly string SchemaFile = "NUnit2TestResult.xsd";

        /// <summary>
        /// The engine.
        /// </summary>
        private ITestEngine engine;

        /// <summary>
        /// The local directory.
        /// </summary>
        private string localDirectory;

        /// <summary>
        /// Gets or sets the engine result.
        /// </summary>
        private TestEngineResult engineResult;

        /// <summary>
        /// Runs the test in given assembly against the provided source assembly.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="TestResult"/>.
        /// </returns>
        public TestResult RunTests(TestRunRequest request)
        {
            Uri uri = new Uri(request.TestAssembly.CodeBase);
            this.localDirectory = Path.GetDirectoryName(uri.LocalPath);
            this.engine = TestEngineActivator.CreateInstance(null, InternalTraceLevel.Off);

            var settings = new Dictionary<string, object>();

            var runner = new DefaultTestAssemblyRunner(new DefaultTestAssemblyBuilder());
            runner.Load(request.TestAssembly, settings);

            // Convert our own framework XmlNode to a TestEngineResult
            var package = new TestPackage(this.GetLocalPath(uri.AbsolutePath));

            this.engineResult = TestEngineResult.MakeTestRunResult(
                package,
                DateTime.Now,
                new TestEngineResult(
                    runner.Run(TestListener.NULL, NUnit.Framework.Internal.TestFilter.Empty).ToXml(true).OuterXml));

            return this.SummaryTransformTest();
        }

        /// <summary>
        /// Transforms the Engine result xml to a required readable format.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private TestResult SummaryTransformTest()
        {
            var transformPath = this.GetLocalPath("Summary.xslt");
            StringWriter writer = new StringWriter();
            new XmlTransformOutputWriter(transformPath).WriteResultFile(this.engineResult.Xml, writer);
            TestResult result = new TestResult();

            if (this.engineResult.Xml.Attributes["failed"] != null)
            {
                result.Failed = Convert.ToInt32(this.engineResult.Xml.Attributes["failed"].Value);
            }

            if (this.engineResult.Xml.Attributes["passed"] != null)
            {
                result.Passed = Convert.ToInt32(this.engineResult.Xml.Attributes["passed"].Value);
            }

            if (this.engineResult.Xml.Attributes["total"] != null)
            {
                result.Total = Convert.ToInt32(this.engineResult.Xml.Attributes["total"].Value);
            }

            // Arrange failed tests summary details
            var xml = XDocument.Load(new XmlNodeReader(this.engineResult.Xml));
            string details = string.Empty;
            IEnumerable<XElement> textSegs = xml.Descendants("test-case")
                .Where(x => x.Attribute("result").Value.Equals("Failed", StringComparison.InvariantCultureIgnoreCase));

            if (textSegs.Any())
            {
                foreach (var seg in textSegs)
                {
                    var testCaseDescription = seg.Descendants("property")
                        .FirstOrDefault(x => x.Attribute("name") != null && x.Attribute("name").Value == "Description");

                    details = string.Format(
                        "\n\n\n TestCase: {0}",
                        // \n Failing message:",
                        testCaseDescription != null
                            ? testCaseDescription.Attribute("value").Value
                            : seg.Attributes("name").First().Value);
                        //seg.Descendants("message").First().Value);
                }
            }

            result.StringResult = details;
            return result;
        }

        /// <summary>
        /// Loads the assembly that contains tests and run the tests.
        /// </summary>
        /// <param name="testAssembly">
        /// Assembly that will be containing tests
        /// </param>
        private void LoadTestAndRunningAssembly(Assembly testAssembly)
        {
            Uri uri = new Uri(testAssembly.CodeBase);
            this.localDirectory = Path.GetDirectoryName(uri.LocalPath);
            this.engine = TestEngineActivator.CreateInstance(null, InternalTraceLevel.Off);

            var settings = new Dictionary<string, object>();

            var runner = new DefaultTestAssemblyRunner(new DefaultTestAssemblyBuilder());
            Assert.True(runner.Load(testAssembly, settings), "Unable to load Executing Assembly.");

            // Convert our own framework XmlNode to a TestEngineResult
            var package = new TestPackage(this.GetLocalPath(uri.AbsolutePath));

            this.engineResult = TestEngineResult.MakeTestRunResult(
                package,
                DateTime.Now,
                new TestEngineResult(
                    runner.Run(TestListener.NULL, NUnit.Framework.Internal.TestFilter.Empty).ToXml(true).OuterXml));
        }

        /// <summary>
        /// The get local path.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetLocalPath(string fileName)
        {
            return Path.Combine(this.localDirectory, fileName);
        }
    }
}
