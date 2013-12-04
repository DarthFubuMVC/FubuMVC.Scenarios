using FubuMVC.Core.Registration;
using FubuMVC.Scenarios.StoryTeller;

namespace FubuMVC.Scenarios
{
    public class ScenarioServiceRegistry : ServiceRegistry
    {
        public ScenarioServiceRegistry()
        {
            SetServiceIfNone<IScenarioContext>(new ScenarioContext());
            SetServiceIfNone<IScenarioRegistry, ScenarioRegistry>();
            SetServiceIfNone<IScenarioReset, ScenarioReset>();
            
            SetServiceIfNone<IScenarioSystemFactory, ScenarioSystemFactory>();
            SetServiceIfNone<IStoryTellerHandler, NulloStoryTellerHandler>();
            SetServiceIfNone<IStoryTellerRedirect, StoryTellerRedirect>();
            SetServiceIfNone<IStoryTellerRunner, StoryTellerRunner>();

            AddService<IScenarioSource, StoryTellerScenarioSource<ScenarioFiles>>();
        }
    }
}