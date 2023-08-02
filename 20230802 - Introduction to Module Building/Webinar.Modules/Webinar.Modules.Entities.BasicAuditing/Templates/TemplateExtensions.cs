using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Webinar.Modules.Entities.BasicAuditing.Templates.AuditedInterface;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Webinar.Modules.Entities.BasicAuditing.Templates
{
    public static class TemplateExtensions
    {
        public static string GetAuditedInterfaceName(this IIntentTemplate template)
        {
            return template.GetTypeName(AuditedInterfaceTemplate.TemplateId);
        }

    }
}