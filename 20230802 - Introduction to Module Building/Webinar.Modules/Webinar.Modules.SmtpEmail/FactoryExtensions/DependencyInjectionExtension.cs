using System.Linq;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.VisualStudio;
using Intent.Plugins.FactoryExtensions;
using Intent.RoslynWeaver.Attributes;
using Webinar.Modules.SmtpEmail.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.FactoryExtension", Version = "1.0")]

namespace Webinar.Modules.SmtpEmail.FactoryExtensions
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class DependencyInjectionExtension : FactoryExtensionBase
    {
        public override string Id => "Webinar.Modules.SmtpEmail.DependencyInjectionExtension";

        [IntentManaged(Mode.Ignore)]
        public override int Order => 0;

        protected override void OnAfterTemplateRegistrations(IApplication application)
        {
            var template = application.FindTemplateInstance<ICSharpFileBuilderTemplate>("Intent.Infrastructure.DependencyInjection.DependencyInjection");
            if (template != null)
            {
                template.AddNugetDependency(new NugetPackageInfo("Microsoft.Extensions.Options.ConfigurationExtensions", "7.0.0"));
                template.CSharpFile.OnBuild(file =>
                {
                    var method = file.Classes.First().FindMethod("AddInfrastructure");
                    method.AddStatement($@"services.Configure<{template.GetSmtpSettingsName()}>(configuration.GetSection(""SmtpSettings""));");
                    method.AddStatement($@"services.AddTransient<{template.GetEmailServiceInterfaceName()}, {template.GetEmailServiceName()}>();");
                });
            }
        }
    }
}