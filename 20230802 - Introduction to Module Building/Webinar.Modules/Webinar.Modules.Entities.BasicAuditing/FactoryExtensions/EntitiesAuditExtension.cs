using System.Linq;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Plugins.FactoryExtensions;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using Webinar.Modules.Entities.BasicAuditing.Api;
using Webinar.Modules.Entities.BasicAuditing.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.FactoryExtension", Version = "1.0")]

namespace Webinar.Modules.Entities.BasicAuditing.FactoryExtensions
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class EntitiesAuditExtension : FactoryExtensionBase
    {
        public override string Id => "Webinar.Modules.Entities.BasicAuditing.EntitiesAuditExtension";

        [IntentManaged(Mode.Ignore)]
        public override int Order => 0;

        protected override void OnAfterTemplateRegistrations(IApplication application)
        {
            var templates = application.FindTemplateInstances<ICSharpFileBuilderTemplate>(TemplateDependency.OnTemplate("Intent.Entities.DomainEntity"));
            foreach (var template in templates)
            {
                var model = (template as ITemplateWithModel)?.Model as ClassModel;
                if (model?.HasAudited() == true)
                {
                    template.CSharpFile.OnBuild(file =>
                    {
                        var @class = file.Classes.First();
                        @class.ImplementsInterface(template.GetAuditedInterfaceName());

                    });
                }

            }
        }
    }
}