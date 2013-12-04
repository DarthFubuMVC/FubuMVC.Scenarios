using FubuMVC.Core.Continuations;

namespace FubuMVC.Scenarios.Tests
{
    public class StubScenario : IScenario
    {
        public StubScenario(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }

        public FubuContinuation Execute()
        {
            throw new System.NotImplementedException();
        }

        protected bool Equals(StubScenario other)
        {
            return string.Equals(Title, other.Title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StubScenario) obj);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}