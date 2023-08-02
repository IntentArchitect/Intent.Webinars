using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.BasicEntities.EntityBase", Version = "1.0")]

namespace TestApplication
{
    public class EntityBase
    {

        protected EntityBase()
        {
        }
    }
}