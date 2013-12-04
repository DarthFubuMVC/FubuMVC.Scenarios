using StoryTeller.Domain;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.StoryTeller
{
    public interface IStoryTellerRunner
    {
        TestResult Run(Test test);
    }

    public class StoryTellerRunner : IStoryTellerRunner
    {
        private readonly IScenarioSystemFactory _systemFactory;

        public StoryTellerRunner(IScenarioSystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }

        public TestResult Run(Test test)
        {
            var system = _systemFactory.System();
            var runner = TestRunner.ForSystem(system);
            
            return runner.RunTest(test);
        }
    }
}