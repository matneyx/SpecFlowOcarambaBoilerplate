using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SpecFlowOcarambaBoilerplate
{
    using System;
    using NUnit.Framework;
    using Ocaramba;
    using Ocaramba.Logger;
    using TechTalk.SpecFlow;

    /// <summary>
    /// The base class for all tests <see href="https://github.com/ObjectivityLtd/Ocaramba/wiki/ProjectTestBase-class">More details on wiki</see>.
    /// </summary>
    [Binding]
    internal class IntegrationTestSetup : TestBase
    {
        private readonly DriverContext driverContext = new DriverContext();
        private readonly ScenarioContext scenarioContext;

        public IntegrationTestSetup(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException(nameof(scenarioContext));
            }

            this.scenarioContext = scenarioContext;
        }

        internal TestLogger LogTest
        {
            get
            {
                return this.DriverContext.LogTest;
            }

            set
            {
                this.DriverContext.LogTest = value;
            }
        }

        protected DriverContext DriverContext => this.driverContext;

        [After]
        internal void AfterTest()
        {
            try
            {
                this.DriverContext.IsTestFailed = this.scenarioContext.TestError != null || !this.driverContext.VerifyMessages.Count.Equals(0);
                var filePaths = this.SaveTestDetailsIfTestFailed(this.driverContext);
                this.SaveAttachmentsToTestContext(filePaths);
                var javaScriptErrors = this.DriverContext.LogJavaScriptErrors();

                this.LogTest.LogTestEnding(this.driverContext);
                if (this.IsVerifyFailedAndClearMessages(this.driverContext) && this.scenarioContext.TestError == null)
                {
                    Assert.Fail();
                }

                if (javaScriptErrors)
                {
                    Assert.Fail("JavaScript errors found. See the logs for details");
                }
            }
            finally
            {
                // the context should be cleaned up no matter what
                this.DriverContext.Stop();
            }
        }

        [Before]
        internal void BeforeTest()
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.driverContext);

            this.DriverContext.DriverOptionsSet += DriverContext_DriverOptionsSet;

            this.DriverContext.Start();
            this.scenarioContext[nameof(this.DriverContext)] = this.DriverContext;
        }

        private static void DriverContext_DriverOptionsSet(object sender, DriverOptionsSetEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.DriverOptions == null)
            {
                throw new NullReferenceException(nameof(args.DriverOptions));
            }

            args.DriverOptions.AddAdditionalCapability("useAutomationExtension", false);
        }

        private void SaveAttachmentsToTestContext(string[] filePaths)
        {
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    this.LogTest.Info("Uploading file [{0}] to test context", filePath);
                    TestContext.AddTestAttachment(filePath);
                }
            }
        }
    }
}
