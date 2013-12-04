using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Scenarios.Tests
{
    [TestFixture]
    public class ScenarioRegistryTester
    {
        private IScenario s1;
        private IScenario s2;
        private IScenario s3;
        private IScenario s4;

        private IScenarioSource src1;
        private IScenarioSource src2;
        private IScenarioSource src3;

        private ScenarioRegistry theRegistry;

        [SetUp]
        public void SetUp()
        {
            s1 = new StubScenario("Scenario 1");
            s2 = new StubScenario("Scenario 2");
            s3 = new StubScenario("Scenario 3");
            s4 = new StubScenario("Scenario 4");

            src1 = MockRepository.GenerateStub<IScenarioSource>();
            src1.Stub(x => x.Scenarios()).Return(new[] {s1});

            src2 = MockRepository.GenerateStub<IScenarioSource>();
            src2.Stub(x => x.Scenarios()).Return(new[] { s2 });

            src3 = MockRepository.GenerateStub<IScenarioSource>();
            src3.Stub(x => x.Scenarios()).Return(new[] { s3, s4 });

            theRegistry = new ScenarioRegistry(new[] { src1, src2, src3 });
        }

        [Test]
        public void aggregates_the_scenarios()
        {
            theRegistry.All().ShouldHaveTheSameElementsAs(s1, s2, s3, s4);
        }

        [Test]
        public void finds_the_scenario()
        {
            theRegistry.Find(s3.Id()).ShouldEqual(s3);
        }
    }
}