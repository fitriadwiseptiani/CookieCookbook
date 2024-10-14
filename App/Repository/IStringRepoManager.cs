namespace Cookbook.App.Repository;

public interface IStringRepoManager
{
    void SaveRecipes(Recipe recipe, string recipeLine);
    List<string> ReadRecipe();
    List<string> LoadFile();
}
