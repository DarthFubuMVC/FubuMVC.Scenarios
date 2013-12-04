using FubuMVC.Core.Continuations;
using StoryTeller.Domain;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class StoryTellerScenario : IScenario
    {
        private readonly Test _test;
        private readonly IStoryTellerRunner _runner;
        private readonly IStoryTellerRedirect _redirect;

        public StoryTellerScenario(Test test, IStoryTellerRunner runner, IStoryTellerRedirect redirect)
        {
            _test = test;
            _runner = runner;
            _redirect = redirect;
        }

        public string Title { get { return _test.Name; } }

        public FubuContinuation Execute()
        {
            var result = _runner.Run(_test);
            if (result.Counts.WasSuccessful())
            {
                return _redirect.Success(this, result);
            }

            return _redirect.Failure(result);
        }
    }
}