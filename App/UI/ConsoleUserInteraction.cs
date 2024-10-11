namespace Cookbook.App;

public class ConsoleUserInteraction : IUserInteraction
{
    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
    public bool TryRead(string inputPlayer, out int id)
    {
        return Int32.TryParse(inputPlayer, out id);
    }
    public string GetUserInput()
    {
        return Console.ReadLine();
    }
}
