namespace Cookbook.App;

public interface IUserInteraction
{
    void WriteMessage(string message);
    bool TryRead(string inputPlayer, out int id);
    int TryReadInt(string inputPlayer);
    string GetUserInput();
    T TryReadEnum<T>(string input) where T : struct;
}
