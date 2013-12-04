using FubuMVC.Core;

namespace FubuMVC.Scenarios
{
    public class ScenarioExtension : FubuPackageRegistry
    {
        public ScenarioExtension()
        {
            Actions.IncludeType<ScenarioController>();
            Services<ScenarioServiceRegistry>();
        }
    }
}