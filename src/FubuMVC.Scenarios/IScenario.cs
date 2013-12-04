using FubuCore;
using FubuMVC.Core.Continuations;

namespace FubuMVC.Scenarios
{
    public interface IScenario
    {
        string Title { get; }
        FubuContinuation Execute();
    }

    public static class ScenarioExtensions
    {
        public static string Id(this IScenario scenario)
        {
            return scenario.Title.ToHash();
        }
    }
}