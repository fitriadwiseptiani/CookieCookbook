
namespace Cookbook.App.Repository;

public class BaseStringRepoManager : IStringRepoManager
{
    private IUserInteraction _ui = new ConsoleUserInteraction();
    public string _filePath;
    public BaseStringRepoManager(string filePath)
    {
        _filePath = filePath;
    }
    public virtual void SaveRecipes(Recipe recipe, string recipeLine)
    {
        new List<string>();
    }
    public virtual List<string> ReadRecipe()
    {
        return new List<string>();
    }
    public virtual List<string> LoadFile()
    {
        return File.ReadAllLines(_filePath).ToList();
    }
    protected bool ExistingFile()
    {
        if (!File.Exists(_filePath))
        {
            _ui.WriteMessage("No recipes found.");
            return false;
        }
        return true;
    }

}
