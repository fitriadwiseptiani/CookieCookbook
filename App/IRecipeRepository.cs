namespace Cookbook.App;

public interface IRecipeRepository
{
    void SaveRecipes(Recipe recipes);
    List<string> ReadRecipes();
    List<string> LoadFile();
    List<string> AddRecipe(List<string> recipes, string recipeLine);
}
