using System.Collections.Generic;

namespace FubuMVC.Scenarios
{
    public interface IScenarioRegistry
    {
        IScenario Find(string id);
        IEnumerable<IScenario> All();
    }
}