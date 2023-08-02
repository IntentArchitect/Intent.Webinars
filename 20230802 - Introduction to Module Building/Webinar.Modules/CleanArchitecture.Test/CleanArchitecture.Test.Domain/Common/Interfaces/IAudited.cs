using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.Entities.BasicAuditing.AuditedInterface", Version = "1.0")]

namespace CleanArchitecture.Test.Domain.Common.Interfaces
{
    public interface IAudited
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}