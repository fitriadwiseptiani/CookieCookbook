using Cookbook.App.UI;

namespace Cookbook.App.Repository;

public class TxtBasedStringRepo : BaseStringRepoManager
{
    public TxtBasedStringRepo(string filePath) : base(filePath)
    {
    }
    public override void SaveRecipes(Recipe recipe, string recipeLine)
    {
        List<string> recipes = LoadFile();
        recipes.Add(recipeLine);
        File.WriteAllLines(_filePath, recipes);
    }
    public override List<string> LoadFile(){
        if(ExistingFile() == false){
            return new List<string>();
        }
        return File.ReadAllLines(_filePath).ToList();
    }

}
