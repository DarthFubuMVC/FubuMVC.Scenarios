using System.Net;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using FubuMVC.Scenarios.StoryTeller;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.Tests.StoryTeller
{
    [TestFixture]
    public class handling_storyteller_scenario_failures : InteractionContext<StoryTellerRedirect>
    {
        private TestResult theResult;
        private FubuContinuation theContinuation;

        protected override void beforeEach()
        {
            theResult = new TestResult { Html = "<h1>Hello</h1>"};

            theContinuation = ClassUnderTest.Failure(theResult);
        }

        [Test]
        public void writes_the_failure_html()
        {
            MockFor<IOutputWriter>().AssertWasCalled(x => x.Write(MimeType.Html.ToString(), theResult.Html));
        }

        [Test]
        public void ends_with_internal_server_error()
        {
            theContinuation.AssertWasEndedWithStatusCode(HttpStatusCode.InternalServerError);
        }
    }
}