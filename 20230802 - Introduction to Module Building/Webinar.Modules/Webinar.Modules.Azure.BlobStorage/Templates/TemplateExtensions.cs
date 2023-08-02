using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Webinar.Modules.Azure.BlobStorage.Templates.AzureBlobStorageService;
using Webinar.Modules.Azure.BlobStorage.Templates.BlobStorageServiceInterface;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Webinar.Modules.Azure.BlobStorage.Templates
{
    public static class TemplateExtensions
    {
        public static string GetAzureBlobStorageServiceName(this IIntentTemplate template)
        {
            return template.GetTypeName(AzureBlobStorageServiceTemplate.TemplateId);
        }

        public static string GetBlobStorageServiceInterfaceName(this IIntentTemplate template)
        {
            return template.GetTypeName(BlobStorageServiceInterfaceTemplate.TemplateId);
        }

    }
}