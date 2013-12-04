using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Scenarios.Tests
{
    [TestFixture]
    public class ScenarioExtensionsTester
    {
        [Test]
        public void id_is_repeatable()
        {
            var scenario = MockRepository.GenerateStub<IScenario>();
            scenario.Stub(x => x.Title).Return("Hello");

            scenario.Id().ShouldEqual(scenario.Id());
        }
    }
}