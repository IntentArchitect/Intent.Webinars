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

namespace Webinar.Modules.SmtpEmail.Templates.EmailService
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class EmailServiceTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.SmtpEmail.EmailService";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public EmailServiceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("System.Net")
                .AddUsing("System.Net.Mail")
                .AddUsing("System.Threading.Tasks")
                .AddUsing("Microsoft.Extensions.Options")
                .AddClass($"EmailService", @class =>
                {
                    @class.ImplementsInterface(this.GetEmailServiceInterfaceName());
                    @class.AddField(this.GetSmtpSettingsName(), "_smtpSettings");
                    @class.AddConstructor(ctor =>
                    {
                        ctor.AddParameter($"IOptions<{this.GetSmtpSettingsName()}>", "smtpSettings");
                        ctor.AddStatement("_smtpSettings = smtpSettings.Value;");
                    });

                    @class.AddMethod("Task", "SendEmailAsync", method =>
                    {
                        method.Async();
                        method.AddParameter("string", "to");
                        method.AddParameter("string", "subject");
                        method.AddParameter("string", "body");

                        method.AddStatements(@"using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                client.EnableSsl = _smtpSettings.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.FromAddress),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }".ConvertToStatements());
                    });
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