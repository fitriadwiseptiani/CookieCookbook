namespace Cookbook.App;

public interface IRecipeRepository
{
    void SaveRecipes(Recipe recipes);
    List<string> ReadRecipes();
}
