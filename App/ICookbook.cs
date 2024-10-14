using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App;

public interface ICookbook
{
    CookbookErrorCode MakeNewRecipe();
    public void DisplayRecipe();
    public void AddIngredients(Ingredient ingredient, string inputPlayer);
    public void SavingRecipe(Recipe recipe);


}
