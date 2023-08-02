using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Webinar.Modules.SmtpEmail.Templates.EmailService;
using Webinar.Modules.SmtpEmail.Templates.EmailServiceInterface;
using Webinar.Modules.SmtpEmail.Templates.SmtpSettings;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Webinar.Modules.SmtpEmail.Templates
{
    public static class TemplateExtensions
    {
        public static string GetEmailServiceName(this IIntentTemplate template)
        {
            return template.GetTypeName(EmailServiceTemplate.TemplateId);
        }

        public static string GetEmailServiceInterfaceName(this IIntentTemplate template)
        {
            return template.GetTypeName(EmailServiceInterfaceTemplate.TemplateId);
        }

        public static string GetSmtpSettingsName(this IIntentTemplate template)
        {
            return template.GetTypeName(SmtpSettingsTemplate.TemplateId);
        }

    }
}