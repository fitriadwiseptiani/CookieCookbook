using System.Text.Json;
using Cookbook.App.Repository;

namespace Cookbook.App;

public class FileManager : IFileManager, IUserInteraction
{
    IStringRepoManager _stringRepoManager;
    public IStringRepoManager ChooseFormat()
    {
        WriteMessage("Choose format to save recipes: 1. JSON 2. TXT");
        int choice = int.Parse(GetUserInput());

        string filePath;

        if (choice == 1)
        {
            _stringRepoManager = new JsonBasedStringRepo();
        }
        else
        {
            _stringRepoManager = new TxtBasedStringRepo();
        }
        return _stringRepoManager;
    }
    public List<string> LoadFileJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            WriteMessage("No recipes found.");
            return new List<string>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }
    public List<string> LoadFileTxt(string filePath)
    {
        if (!File.Exists(filePath))
        {
            WriteMessage("No recipes found.");
            return new List<string>();
        }
        return File.ReadAllLines(filePath).ToList();
    }

    public bool TryRead(string inputPlayer, out int id)
    {
        return Int32.TryParse(inputPlayer, out id);
    }

    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
    public string GetUserInput()
    {
        return Console.ReadLine();
    }

    public int TryReadInt(string inputPlayer)
    {
        return Int32.Parse(inputPlayer);
    }

}
