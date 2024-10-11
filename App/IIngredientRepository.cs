using Cookbook.Model;

namespace Cookbook.App;

public interface IIngredientRepository
{
    List<Ingredient> GetAvailableIngredients();
    List<Ingredient> GetIngredientsList();
    string GetSelectedIngredients(Recipe recipe);
}
