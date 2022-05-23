public static class BotExt
{
    public static Bot GenerateBot(string namePath,string personalityPath)
    {
        string name=GetLine(namePath);
        string personality=GetLine(personalityPath);
        return new Bot(name,personality);
    }
    private static string GetLine(string filePath)
    {
        string[] lines=File.ReadAllLines(@$"{Environment.CurrentDirectory}/{filePath}");
        int size=lines.Length;
        Random rnd=new Random();
        return lines[rnd.Next(size)];
    }
}
public static class PlayerExt
{
    public static async Task Save(this Player p)
    {
        string[] data={p.Name,p.Email,p.Id.ToString()};
        await File.WriteAllLinesAsync($"{data[2]}.player",data);

    }
    public static Player Load(string filePath)
    {
        string[] lines=File.ReadAllLines(@$"{filePath}");
        return new Player(lines[0],lines[1],lines[2]);
    }
    public static List<User> LoadAll(string directoryPath)
    {
        List<User> players=new List<User>();
        string[] files=Directory.GetFiles(@$"{Environment.CurrentDirectory}");
        foreach (string f in files)
        {
            if (f.Contains(".player")) players.Add(Load(f));
        }
        return players;
    }
}