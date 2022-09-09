using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TrainingPlannerAppMVC.Infrastructure.Binders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
        var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueResult == ValueProviderResult.None) return Task.CompletedTask;

        var value = valueResult.FirstValue;

        if (string.IsNullOrEmpty(value)) return Task.CompletedTask;

        var myValue = value.Replace('.', ',').Trim();

        if (!decimal.TryParse(myValue, out var actualValue))
        {
            bindingContext.ModelState.TryAddModelError(
                bindingContext.ModelName,
                "Cannot parse value to decimal!"
            );

            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(actualValue);
        return Task.CompletedTask;
    }
}