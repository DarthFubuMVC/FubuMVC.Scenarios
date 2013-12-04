using System.Collections.Generic;
using System.Linq;

namespace FubuMVC.Scenarios
{
    public class ScenarioRegistry : IScenarioRegistry
    {
        private readonly IEnumerable<IScenarioSource> _sources;

        public ScenarioRegistry(IEnumerable<IScenarioSource> sources)
        {
            _sources = sources;
        }

        public IScenario Find(string id)
        {
            return All().SingleOrDefault(x => ScenarioExtensions.Id(x) == id);
        }

        public IEnumerable<IScenario> All()
        {
            return _sources.SelectMany(x => x.Scenarios());
        }
    }
}