using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TrainingPlannerAppMVC.Application.Binders;

public class DecimalBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (context.Metadata.ModelType == typeof(decimal)) return new DecimalModelBinder();

        return null;
    }
}