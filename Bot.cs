public class Bot : User
{
    private readonly Guid _id=Guid.NewGuid();
    private string _personality;
    public string Personality{get{return _personality;}}
    public Bot(string name,string personality):base(name){_personality=personality;}
}