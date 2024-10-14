using Cookbook.Model;

namespace Cookbook.App.Repository;

public class IngredientRepository : IIngredientRepository
{
    private List<Ingredient> _availableIngredients;
    public IEnumerable<Ingredient> AvailableIngredients => _availableIngredients;
    public IngredientRepository(List<Ingredient> availableIngredients)
    {
        _availableIngredients = availableIngredients;
    }
    public IEnumerable<Ingredient> GetIngredientsList()
    {
        return AvailableIngredients;
    }
    public string GetSelectedIngredients(Recipe recipe)
    {
        if (recipe._ingredients.Count == 0)
        {
            throw new Exception("No ingredients selected. Recipe will not be saved.");
        }
        var selectedIds = recipe._ingredients.Select(i => i.Id).Distinct();
        return $"Selected ingredients: {string.Join(", ", selectedIds)}";
    }

}
