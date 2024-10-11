namespace Cookbook.App;

public interface IUserInteraction
{
    void WriteMessage(string message);
    bool TryRead(string inputPlayer, out int id);
    string GetUserInput();
}
