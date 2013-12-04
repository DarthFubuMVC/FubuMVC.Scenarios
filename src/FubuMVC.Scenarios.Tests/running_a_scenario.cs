using System.Net;
using FubuMVC.Core.Continuations;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Scenarios.Tests
{
    [TestFixture]
    public class running_a_scenario : InteractionContext<ScenarioController>
    {
        private IScenario theScenario;
        private ScenarioRequest theRequest;
        private FubuContinuation theContinuation;

        protected override void beforeEach()
        {
            theScenario = MockFor<IScenario>();
            theRequest = new ScenarioRequest {Id = "1234"};

            MockFor<IScenarioRegistry>().Stub(x => x.Find(theRequest.Id)).Return(theScenario);
            theScenario.Stub(x => x.Execute()).Return(FubuContinuation.EndWithStatusCode(HttpStatusCode.Forbidden));

            theContinuation = ClassUnderTest.get_scenario_Id(theRequest);
        }

        [Test]
        public void executes_the_scenario()
        {
            theScenario.AssertWasCalled(x => x.Execute());
        }

        [Test]
        public void returns_the_continuation_from_the_scenario()
        {
            theContinuation.AssertWasEndedWithStatusCode(HttpStatusCode.Forbidden);
        }

        [Test]
        public void sets_the_scenario_context()
        {
            MockFor<IScenarioContext>().AssertWasCalled(x => x.SetCurrent(theScenario));
        }
    }
}