using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Test.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace CleanArchitecture.Test.Application.SendEmail
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly IEmailService _emailService;

        [IntentManaged(Mode.Merge)]
        public SendEmailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailAsync("info@intentarchitect.com", "Test Email", "This is a test email for the webinar");
        }
    }
}