using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuMVC.Core.Runtime.Files;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class ScenarioFiles : IScenarioFiles
    {
        private readonly IFubuApplicationFiles _files;
        private readonly ScenarioFilesSettings _settings;

        public ScenarioFiles(IFubuApplicationFiles files, ScenarioFilesSettings settings)
        {
            _files = files;
            _settings = settings;
        }

        public IEnumerable<string> Files()
        {
            return _files
                .AllFolders
                .Where(x => _settings.ShouldInclude(x.Provenance))
                .SelectMany(x => x.FindFiles(FileSet.Deep("Tests/Scenarios/*.xml")))
                .Select(x => x.Path);
        }
    }
}