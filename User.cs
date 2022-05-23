public abstract class User : IUser
{
    private readonly Guid _id;
    private string _name="";
    public Guid Id {get {return _id;}}
    public string Name{get{return _name;} set{_name=value;}}
    public delegate void PrintUserInfo(User u);
    public User(string name) {_name=name; _id=Guid.NewGuid();}
    public User(string name, string id) {_name=name;_id=Guid.Parse(id);}
    public void Print(PrintUserInfo f, User u)
    {
            f(u);
    }
}