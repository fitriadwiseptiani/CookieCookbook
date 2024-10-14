using Cookbook.Enums;

namespace Cookbook.App;

public interface ICookbookInteraction : IUserInteraction
{   
    UserAction ChooseAction();
    void SelectedIngredient();
    void DisplayAvailableIngredient();
    void Finished();
    void RecipeStatus(CookbookErrorCode result);
    string FormatSingleRecipe(List<int> ingredientIds);
    void DisplayRecipe(List<string> recipe);
}
