using FubuCore;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.StoryTeller
{
    public interface IScenarioSystemFactory
    {
        ISystem System();
    }

    public class ScenarioSystemFactory : IScenarioSystemFactory
    {
        private readonly IServiceLocator _services;

        public ScenarioSystemFactory(IServiceLocator services)
        {
            _services = services;
        }

        public ISystem System()
        {
            return _services.GetInstance<ScenarioSystem>();
        }
    }
}