using System.Net;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class StoryTellerRedirect : IStoryTellerRedirect
    {
        private readonly IOutputWriter _writer;
        private readonly IStoryTellerHandler _handler;

        public StoryTellerRedirect(IOutputWriter writer, IStoryTellerHandler handler)
        {
            _writer = writer;
            _handler = handler;
        }

        public FubuContinuation Failure(TestResult test)
        {
            _writer.WriteHtml(test.Html);
            return FubuContinuation.EndWithStatusCode(HttpStatusCode.InternalServerError);
        }

        public FubuContinuation Success(IScenario scenario, TestResult test)
        {
            _handler.Success(scenario);
            return FubuContinuation.RedirectTo("~/");
        }
    }
}