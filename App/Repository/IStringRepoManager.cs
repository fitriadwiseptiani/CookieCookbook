namespace Cookbook.App.Repository;

public interface IStringRepoManager
{
    void SaveRecipes(List<string> recipes, string recipeLine);
    List<string> ReadRecipe();
    List<string> LoadFile();
}
