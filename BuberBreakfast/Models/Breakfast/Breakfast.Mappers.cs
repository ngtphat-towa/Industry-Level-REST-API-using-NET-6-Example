using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models.Breakfast;
public static class BreakfastAPIRequestMapper
{
    public static ErrorOr<Breakfast> Create(
       string name,
       string description,
       DateTime startDateTime,
       DateTime endDateTime,
       List<string> savory,
       List<string> sweet,
       Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < BreakfastContrainsts.MinNameLength or > BreakfastContrainsts.MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (description.Length is < BreakfastContrainsts.MinDescriptionLength or > BreakfastContrainsts.MaxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet);
    }

    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet);
    }

    public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id);
    }
}
