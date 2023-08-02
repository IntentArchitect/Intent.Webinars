using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Webinar.Modules.BasicEntities.Templates.Entity;
using Webinar.Modules.BasicEntities.Templates.EntityBase;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Webinar.Modules.BasicEntities.Templates
{
    public static class TemplateExtensions
    {
        public static string GetEntityName<T>(this IIntentTemplate<T> template) where T : Intent.Modelers.Domain.Api.ClassModel
        {
            return template.GetTypeName(EntityTemplate.TemplateId, template.Model);
        }

        public static string GetEntityName(this IIntentTemplate template, Intent.Modelers.Domain.Api.ClassModel model)
        {
            return template.GetTypeName(EntityTemplate.TemplateId, model);
        }

        public static string GetEntityBaseName(this IIntentTemplate template)
        {
            return template.GetTypeName(EntityBaseTemplate.TemplateId);
        }

    }
}