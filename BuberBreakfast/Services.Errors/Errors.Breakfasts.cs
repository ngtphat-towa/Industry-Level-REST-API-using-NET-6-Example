using BuberBreakfast.Models.Breakfast;
using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error InvalidName => Error.Validation(
            code: "Breakfast.InvalidName"
            ,
            description: $"Breakfast name must be at least {BreakfastContrainsts.MinNameLength}" +
                $" characters long and at most {BreakfastContrainsts.MaxNameLength} characters long."
                );

        public static Error InvalidDescription => Error.Validation(
            code: "Breakfast.InvalidDescription"
                ,
                description: $"Breakfast description must be at least {BreakfastContrainsts.MinDescriptionLength}" +
                    $" characters long and at most {BreakfastContrainsts.MaxDescriptionLength} characters long."
                );

        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found");
    }
}