using Cookbook.Model;

namespace Cookbook.App;

public interface IIngredientRepository
{
    IEnumerable<Ingredient> GetIngredientsList();
    string GetSelectedIngredients(Recipe recipe);
}
