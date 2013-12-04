using System.Collections.Generic;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class ScenarioFilesSettings
    {
        private readonly IList<string> _provenances = new List<string>();

        public void IncludeProvenance(string provenance)
        {
            _provenances.Fill(provenance);
        }

        public IEnumerable<string> Provenances { get { return _provenances; } } 

        public bool ShouldInclude(string provenance)
        {
            return _provenances.Contains(provenance);
        }
    }
}