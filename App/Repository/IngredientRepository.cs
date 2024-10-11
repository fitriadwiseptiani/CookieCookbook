using Cookbook.Model;

namespace Cookbook.App.Repository;

public class IngredientRepository : IIngredientRepository
{
    public IngredientRepository()
    {
    }
    public List<Ingredient> GetAvailableIngredients()
    {
        var _ingredient = new List<Ingredient>{
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocoaPowder()
        };
        return _ingredient;
    }
    public List<Ingredient> GetIngredientsList()
    {
        return GetAvailableIngredients();
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
