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

namespace Webinar.Modules.SmtpEmail.Templates.SmtpSettings
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class SmtpSettingsTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.SmtpEmail.SmtpSettings";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public SmtpSettingsTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddClass($"SmtpSettings", @class =>
                {
                    @class.AddProperty("string", "Host");
                    @class.AddProperty("int", "Port");
                    @class.AddProperty("string", "Username");
                    @class.AddProperty("string", "Password");
                    @class.AddProperty("bool", "EnableSsl");
                    @class.AddProperty("string", "FromAddress");
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