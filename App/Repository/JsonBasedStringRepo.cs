using System.Text.Json;
using Cookbook.App.UI;

namespace Cookbook.App.Repository;

public class JsonBasedStringRepo : BaseStringRepoManager
{
    public JsonBasedStringRepo(string filePath) : base(filePath)
    {
    }
    public override void SaveRecipes(List<string> recipes, string recipeLine)
    {
        // List<string> recipes = LoadFile();
        // recipes.Add(recipeLine);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, serializedJson);
    }
    public override List<string> LoadFile()
    {
        if(ExistingFile() == false){
            return new List<string>();
        }
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }
}
