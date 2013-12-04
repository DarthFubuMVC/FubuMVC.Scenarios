using System.Collections.Generic;
using FubuCore;
using FubuMVC.ContentExtensions;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI;
using HtmlTags;

namespace FubuMVC.Scenarios
{
    public class ScenariosList { }

    public class ScenarioDocument : FubuHtmlDocument<ScenariosList>
    {
        public const string Header = "scenarios:header";
        public const string Footer = "scenarios:footer";

        public ScenarioDocument(IServiceLocator services) 
            : base(services, services.GetInstance<IFubuRequest>())
        {
            Title = "Scenarios";

            writeStyles();
            writeHeader();

            Add(new LiteralTag(this.WriteExtensions(Header).ToString()));

            writeReset();
            Fill();

            Add(new LiteralTag(this.WriteExtensions(Footer).ToString()));
        }

        private void writeStyles()
        {
            Body.Style("font-family", "Helvetica, Arial, sans-serif;");
            Body.Style("font-size", "14px");
            Body.Style("color", "#333");
        }

        private void writeHeader()
        {
            Add("h1")
                .Style("border-bottom", "1px solid #333;")
                .Style("width", "50%")
                .Text("Scenarios");

            var block = Add("blockquote")
                .Style("padding", "10px")
                .Style("border", "1px dashed #ccc")
                .Style("width", "40%");

            block.Add("strong").AppendHtml("Note:<br/>");
            block.AppendHtml("Running a scenario will temporarily wipe the existing database.<br/>");
            block.AppendHtml("Your data will not be lost but it will be made unavailable until the application is reset.<br/>");
            block.AppendHtml("If you wish to reset the application, use the Reset link.");
        }

        private void writeReset()
        {
            Add("a").Text("[Reset Application]").Attr("href", Urls.UrlFor<ScenarioController>(x => x.get_scenarios_reset()));
        }

        public void Fill()
        {
            Add("h3").Text("Choose a scenario to run:");

            Push("ul");

            var registry = Get<IScenarioRegistry>();
            var scenarios = registry.All();

            scenarios.Each(scenario =>
            {
                var url = Urls.UrlFor(new ScenarioRequest { Id = scenario.Id() });
                Add("li/a").Text(scenario.Title).Attr("href", url);
            });

            Pop();
        }
    }
}