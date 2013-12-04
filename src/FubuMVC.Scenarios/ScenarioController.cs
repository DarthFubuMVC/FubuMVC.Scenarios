using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using HtmlTags;

namespace FubuMVC.Scenarios
{
    [NotAuthenticated]
    public class ScenarioController
    {
        private readonly IServiceLocator _services;
        private readonly IScenarioReset _reset;
        private readonly IScenarioRegistry _registry;
        private readonly IScenarioContext _context;

        public ScenarioController(IServiceLocator services, IScenarioReset reset, IScenarioRegistry registry, IScenarioContext context)
        {
            _services = services;
            _reset = reset;
            _registry = registry;
            _context = context;
        }

        public ScenarioDocument get_scenarios()
        {
            return new ScenarioDocument(_services);
        }

        public FubuContinuation get_scenario_Id(ScenarioRequest request)
        {
            var scenario = _registry.Find(request.Id);
            _context.SetCurrent(scenario);
            return scenario.Execute();
        }

        public FubuContinuation get_scenarios_reset()
        {
            return _reset.Reset();
        }

        [UrlPattern("_scenario")]
        public HtmlDocument get_scenario()
        {
            var scenario = _context.Current();
            HtmlTag current = null;

            if (scenario != null)
            {
                current = new HtmlTag("h1").Text("Current scenario: " + scenario.Title);
            }
            else
            {
                current = new HtmlTag("h1").Text("No scenario loaded");
            }

            var doc = new HtmlDocument();
            doc.Add(current);
            return doc;
        }
    }
}