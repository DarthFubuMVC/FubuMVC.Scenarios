using System;
using System.IO;
using FubuCore;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime.Files;

namespace FubuMVC.Scenarios
{
    public interface IScenarioReset
    {
        FubuContinuation Reset();
    }

    public class ScenarioReset : IScenarioReset
    {
        private readonly IFubuApplicationFiles _files;

        public ScenarioReset(IFubuApplicationFiles files)
        {
            _files = files;
        }

        public FubuContinuation Reset()
        {
            var config = _files.GetApplicationPath().AppendPath("Web.config");
            File.SetLastWriteTimeUtc(config, DateTime.UtcNow);

            return redirect();
        }

        protected virtual FubuContinuation redirect()
        {
            return FubuContinuation.RedirectTo("~/");
        }
    }
}