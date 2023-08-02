using System;
using System.Collections.Generic;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.CSharp.TypeResolvers;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Webinar.Modules.BasicEntities.Templates.Entity
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public partial class EntityTemplate : CSharpTemplateBase<ClassModel>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Webinar.Modules.BasicEntities.Entity";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public EntityTemplate(IOutputTarget outputTarget, ClassModel model) : base(TemplateId, outputTarget, model)
        {
            SetDefaultCollectionFormatter(CSharpCollectionFormatter.CreateList());
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddClass($"{Model.Name}", @class =>
                {
                    foreach (var attribute in Model.Attributes)
                    {
                        @class.AddProperty(GetTypeName(attribute), attribute.Name.ToPascalCase());
                    }
                    foreach (var association in Model.AssociatedClasses)
                    {
                        @class.AddProperty(GetTypeName(association), association.Name.ToPascalCase());
                    }

                    foreach (var ctorModel in Model.Constructors)
                    {
                        @class.AddConstructor(ctor =>
                        {
                            foreach (var parameter in ctorModel.Parameters)
                            {
                                ctor.AddParameter(GetTypeName(parameter), parameter.Name.ToCamelCase());
                            }
                        });
                    }

                    foreach (var operation in Model.Operations)
                    {
                        @class.AddMethod(GetTypeName(operation), operation.Name.ToPascalCase(), ctor =>
                        {
                            foreach (var parameter in operation.Parameters)
                            {
                                ctor.AddParameter(GetTypeName(parameter), parameter.Name.ToCamelCase());
                            }
                        });
                    }
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