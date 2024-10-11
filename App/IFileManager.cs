using Cookbook.App.Repository;

namespace Cookbook.App;

public interface IFileManager
{
    IStringRepoManager ChooseFormat();
    List<string> LoadFileJson(string filePath);
    List<string> LoadFileTxt(string filePath);
}
