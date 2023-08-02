using System;
using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Webinar.Modules.Azure.BlobStorage.Templates.BlobStorageServiceInterface
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class BlobStorageServiceInterfaceTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.Azure.BlobStorage.BlobStorageServiceInterface";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public BlobStorageServiceInterfaceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("Azure.Storage.Blobs")
                .AddUsing("System.IO")
                .AddUsing("System.Threading.Tasks")
                .AddInterface("IBlobStorageService", @interface =>
                {
                    @interface
                        .AddMethod("Task<BlobClient>", "UploadAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName")
                            .AddParameter("Stream", "content"))
                        .AddMethod("Task<Stream>", "DownloadAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName"))
                        .AddMethod("Task", "DeleteAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName"));
                });
        }

        [IntentManaged(Mode.Fully)]
        public CSharpFile CSharpFile { get; }

        [IntentManaged(Mode.Fully)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return CSharpFile.GetConfig();
        }

        [IntentManaged(Mode.Fully)]
        public override string TransformText()
        {
            return CSharpFile.ToString();
        }
    }
}