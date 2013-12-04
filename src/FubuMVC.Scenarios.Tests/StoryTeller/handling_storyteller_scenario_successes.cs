using FubuMVC.Core.Continuations;
using FubuMVC.Scenarios.StoryTeller;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.Tests.StoryTeller
{
    [TestFixture]
    public class handling_storyteller_scenario_successes : InteractionContext<StoryTellerRedirect>
    {
        private TestResult theResult;
        private FubuContinuation theContinuation;

        protected override void beforeEach()
        {
            theResult = new TestResult();
            theContinuation = ClassUnderTest.Success(MockFor<IScenario>(), theResult);
        }

        [Test]
        public void invokes_the_handler()
        {
            MockFor<IStoryTellerHandler>().AssertWasCalled(x => x.Success(MockFor<IScenario>()));
        }

        [Test]
        public void redirects_to_home()
        {
            theContinuation.AssertWasRedirectedTo("~/");
        }
    }
}