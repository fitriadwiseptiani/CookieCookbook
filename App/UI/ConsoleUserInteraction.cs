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
    public int TryReadInt(string inputPlayer)
    {
        return Int32.Parse(inputPlayer);
    }
    public T TryReadEnum<T>(string input) where T : struct
    {
        if (Enum.TryParse(input, true, out T result))
        {
            return result;
        }
        else
        {
            throw new Exception();
        }
    }

    public string GetUserInput()
    {
        return Console.ReadLine();
    }
}
