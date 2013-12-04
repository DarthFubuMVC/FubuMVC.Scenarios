namespace FubuMVC.Scenarios.StoryTeller
{
    public interface IStoryTellerHandler
    {
        void Success(IScenario scenario);
    }

    public class NulloStoryTellerHandler : IStoryTellerHandler
    {
        public void Success(IScenario scenario)
        {
        }
    }
}