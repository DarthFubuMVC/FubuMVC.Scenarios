namespace FubuMVC.Scenarios
{
    public interface IScenarioContext
    {
        IScenario Current();
        void SetCurrent(IScenario scenario);
    }

    public class ScenarioContext : IScenarioContext
    {
        private IScenario _current;

        public IScenario Current()
        {
            return _current;
        }

        public void SetCurrent(IScenario scenario)
        {
            _current = scenario;
        }
    }

    public static class ScenarioContextExtensions
    {
        public static bool Active(this IScenarioContext context)
        {
            return context.Current() != null;
        }
    }
}