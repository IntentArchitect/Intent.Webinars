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

namespace Webinar.Modules.Azure.BlobStorage.Templates.AzureBlobStorageService
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class AzureBlobStorageServiceTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.Azure.BlobStorage.AzureBlobStorageService";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public AzureBlobStorageServiceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("Azure.Storage.Blobs")
                .AddUsing("System.IO")
                .AddUsing("System.Threading.Tasks")
                .AddClass("AzureBlobStorageService", @class =>
                {
                    @class.ImplementsInterface(this.GetBlobStorageServiceInterfaceName());
                    @class
                        .AddConstructor(ctor => ctor
                            .AddParameter("string", "connectionString")
                            .AddStatement("_blobServiceClient = new BlobServiceClient(connectionString);"))
                        .AddField("private readonly BlobServiceClient", "_blobServiceClient")
                        .AddMethod("public async Task<BlobClient>", "UploadAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName")
                            .AddParameter("Stream", "content")
                            .AddStatement("var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);")
                            .AddStatement("var blobClient = containerClient.GetBlobClient(blobName);")
                            .AddStatement("await blobClient.UploadAsync(content);")
                            .AddStatement("return blobClient;"))
                        .AddMethod("public async Task<Stream>", "DownloadAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName")
                            .AddStatement("var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);")
                            .AddStatement("var blobClient = containerClient.GetBlobClient(blobName);")
                            .AddStatement("var response = await blobClient.DownloadAsync();")
                            .AddStatement("return response.Value.Content;"))
                        .AddMethod("public async Task", "DeleteAsync", method => method
                            .AddParameter("string", "containerName")
                            .AddParameter("string", "blobName")
                            .AddStatement("var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);")
                            .AddStatement("var blobClient = containerClient.GetBlobClient(blobName);")
                            .AddStatement("await blobClient.DeleteIfExistsAsync();"));
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