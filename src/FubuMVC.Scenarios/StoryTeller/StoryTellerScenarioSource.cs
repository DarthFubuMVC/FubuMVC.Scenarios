using System.Collections.Generic;
using System.Linq;
using System.Xml;
using StoryTeller.Domain;
using StoryTeller.Persistence;

namespace FubuMVC.Scenarios.StoryTeller
{
    public class StoryTellerScenarioSource<T> : IScenarioSource
        where T : IScenarioFiles
    {
        private readonly T _files;
        private readonly IStoryTellerRunner _runner;
        private readonly IStoryTellerRedirect _redirect;

        public StoryTellerScenarioSource(T files, IStoryTellerRunner runner, IStoryTellerRedirect redirect)
        {
            _files = files;
            _runner = runner;
            _redirect = redirect;
        }

        public IEnumerable<IScenario> Scenarios()
        {
            return _files.Files().Select(file =>
            {
                var test = readTest(file);
                return new StoryTellerScenario(test, _runner, _redirect);
            });
        }

        private Test readTest(string file)
        {
            var document = new XmlDocument();
            document.Load(file);

            var reader = new TestReader();
            return reader.ReadTest(document.DocumentElement);
        }
    }
}