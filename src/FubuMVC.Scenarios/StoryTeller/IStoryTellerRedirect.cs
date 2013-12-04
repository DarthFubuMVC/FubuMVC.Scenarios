using FubuMVC.Core.Continuations;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.StoryTeller
{
    public interface IStoryTellerRedirect
    {
        FubuContinuation Failure(TestResult test);
        FubuContinuation Success(IScenario scenario, TestResult test);
    }
}