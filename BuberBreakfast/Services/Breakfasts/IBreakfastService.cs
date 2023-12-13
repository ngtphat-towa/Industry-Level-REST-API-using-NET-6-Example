using BuberBreakfast.Models;
namespace BuberBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
    // void<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast);
    // void<Deleted> DeleteBreakfast(Guid id);
}