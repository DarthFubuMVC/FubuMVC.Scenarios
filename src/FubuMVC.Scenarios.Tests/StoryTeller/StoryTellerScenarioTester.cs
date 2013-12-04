using System.Net;
using FubuMVC.Core.Continuations;
using FubuMVC.Scenarios.StoryTeller;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;
using StoryTeller.Domain;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.Tests.StoryTeller
{
    [TestFixture]
    public class StoryTellerScenarioTester : InteractionContext<StoryTellerScenario>
    {
        private Test theTest;

        protected override void beforeEach()
        {
            theTest = new Test("Test") { SuiteName = "Test" };

            Services.Inject(theTest);
        }

        [Test]
        public void successful_run()
        {
            var result = new TestResult();
            result.Counts.Add(new Counts(1, 0, 0, 0));

            MockFor<IStoryTellerRunner>().Stub(x => x.Run(theTest)).Return(result);
            
            MockFor<IStoryTellerRedirect>()
                .Stub(x => x.Success(Arg<IScenario>.Is.NotNull, Arg<TestResult>.Is.Same(result)))
                .Return(FubuContinuation.EndWithStatusCode(HttpStatusCode.OK));

            ClassUnderTest.Execute().AssertWasEndedWithStatusCode(HttpStatusCode.OK);
        }

        [Test]
        public void failed_run()
        {
            var result = new TestResult();
            result.Counts.Add(new Counts(0, 1, 1, 0));

            MockFor<IStoryTellerRunner>().Stub(x => x.Run(theTest)).Return(result);
            MockFor<IStoryTellerRedirect>().Stub(x => x.Failure(result)).Return(FubuContinuation.EndWithStatusCode(HttpStatusCode.InternalServerError));

            ClassUnderTest.Execute().AssertWasEndedWithStatusCode(HttpStatusCode.InternalServerError);
        }
    }
}