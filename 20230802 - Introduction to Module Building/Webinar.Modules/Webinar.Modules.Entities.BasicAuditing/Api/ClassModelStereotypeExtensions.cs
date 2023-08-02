using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Webinar.Modules.Entities.BasicAuditing.Api
{
    public static class ClassModelStereotypeExtensions
    {
        public static Audited GetAudited(this ClassModel model)
        {
            var stereotype = model.GetStereotype("Audited");
            return stereotype != null ? new Audited(stereotype) : null;
        }


        public static bool HasAudited(this ClassModel model)
        {
            return model.HasStereotype("Audited");
        }

        public static bool TryGetAudited(this ClassModel model, out Audited stereotype)
        {
            if (!HasAudited(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Audited(model.GetStereotype("Audited"));
            return true;
        }

        public class Audited
        {
            private IStereotype _stereotype;

            public Audited(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

    }
}