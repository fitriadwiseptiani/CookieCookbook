
namespace Cookbook.App.Repository;

public abstract class BaseStringRepoManager : IStringRepoManager
{
    private IUserInteraction _ui = new ConsoleUserInteraction();
    public string _filePath;
    public BaseStringRepoManager(string filePath)
    {
        _filePath = filePath;
    }
    public abstract void SaveRecipes(List<string> recipes, string recipeLine);
    public abstract List<string> LoadFile();
    protected bool ExistingFile()
    {
        if (!File.Exists(_filePath))
        {
            _ui.WriteMessage("No recipes found.");
            return false;
        }
        return true;
    }
    public List<string> ReadRecipe()
    {
        List<string> recipe = LoadFile();
        return recipe;
    }

}
