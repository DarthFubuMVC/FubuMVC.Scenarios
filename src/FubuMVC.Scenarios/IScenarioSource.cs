using System.Collections.Generic;

namespace FubuMVC.Scenarios
{
    public interface IScenarioSource
    {
        IEnumerable<IScenario> Scenarios();
    }
}