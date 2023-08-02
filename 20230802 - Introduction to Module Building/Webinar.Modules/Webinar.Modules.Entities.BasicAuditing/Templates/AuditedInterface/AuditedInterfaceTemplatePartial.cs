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

namespace Webinar.Modules.Entities.BasicAuditing.Templates.AuditedInterface
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class AuditedInterfaceTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.Entities.BasicAuditing.AuditedInterface";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public AuditedInterfaceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("System")
                .AddInterface($"IAudited", @class =>
                {
                    @class.AddProperty("string", "CreatedBy");
                    @class.AddProperty("DateTime", "CreatedDate");
                    @class.AddProperty("string?", "UpdatedBy");
                    @class.AddProperty("DateTime?", "UpdatedDate");
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