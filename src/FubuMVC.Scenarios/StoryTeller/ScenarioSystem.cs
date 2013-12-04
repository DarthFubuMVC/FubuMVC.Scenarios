using FubuCore;
using FubuCore.Binding;
using StoryTeller.Engine;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class ScenarioSystem : ISystem, IExecutionContext
    {
        private readonly BindingRegistry _registry;
        private readonly IServiceLocator _services;

        public ScenarioSystem(IServiceLocator services, BindingRegistry registry)
        {
            _services = services;
            _registry = registry;
        }

        public IServiceLocator Services
        {
            get { return _services; }
        }

        public BindingRegistry BindingRegistry
        {
            get { return _registry; }
        }

        public IExecutionContext CreateContext()
        {
            return this;
        }

        public void Recycle()
        {
            // no-op
        }

        public void Dispose()
        {
            // no-op
        }


    }
}