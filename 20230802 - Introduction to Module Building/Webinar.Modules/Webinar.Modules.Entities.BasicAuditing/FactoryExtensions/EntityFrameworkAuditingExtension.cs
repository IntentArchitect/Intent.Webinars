using System.Linq;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Plugins;
using Intent.Plugins.FactoryExtensions;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.FactoryExtension", Version = "1.0")]

namespace Webinar.Modules.Entities.BasicAuditing.FactoryExtensions
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class EntityFrameworkAuditingExtension : FactoryExtensionBase
    {
        public override string Id => "Webinar.Modules.Entities.BasicAuditing.EntityFrameworkAuditingExtension";

        [IntentManaged(Mode.Ignore)]
        public override int Order => 0;

        protected override void OnAfterTemplateRegistrations(IApplication application)
        {
            var template = application.FindTemplateInstance<ICSharpFileBuilderTemplate>("Intent.EntityFrameworkCore.DbContext");
            template.CSharpFile.OnBuild(file =>
            {
                file.AddUsing("System");
                var @class = file.Classes.First();
                @class.Constructors.First().AddParameter("ICurrentUserService", "currentUserService", param => param.IntroduceReadonlyField());
                @class.AddMethod("void", "ApplyAuditingInfo", method =>
                {
                    method.AddStatements(@"var entries = ChangeTracker.Entries().Where(e => e.Entity is IAudited && (e.State == EntityState.Added || e.State == EntityState.Modified));
        var userId = _currentUserService.UserId ?? ""Unknown"";
        
        foreach (var entry in entries)
        {
            var auditedEntity = (IAudited)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                auditedEntity.CreatedDate = DateTime.Now;
                auditedEntity.CreatedBy = userId;
            }

            if (entry.State == EntityState.Modified)
            {
                auditedEntity.UpdatedDate = DateTime.Now;
                auditedEntity.UpdatedBy = userId;
            }
        }
".ConvertToStatements());
                });

                @class.FindMethod("SaveChangesAsync")
                    ?.FindStatement(x => x.ToString().TrimStart().StartsWith("return "))
                    ?.InsertAbove("ApplyAuditingInfo();");
            });
        }
    }
}