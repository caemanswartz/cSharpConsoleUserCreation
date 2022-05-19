public interface IUser
{
    Guid Id{get;}
    string Name{get;set;}
    string Email{get;set;}
}
public class User : IUser
{
    private readonly Guid _id = Guid.NewGuid();
    private string _name="";
    private string _email="";
    public Guid Id {get {return _id;}}
    public string Name{get{return _name;} set{_name=value;}}
    public string Email{get{return _email;} set{_email=value;}}
    public User(string name, string email){_name=name;_email=email;}
    public delegate void PrintUserInfo(User u);
    public void Print(PrintUserInfo f, User u)
    {
            f(u);
    }
}
public static class UserExt
{
    public static void PrintName(this User u)
    {
        Console.WriteLine($"Player name: {u.Name}");
    }
    public static void PrintId(this User u)
    {
        Console.WriteLine($"Player id: {u.Id}");
    }
    public static void PrintUserInfo(this User u)
    {
        Console.WriteLine($"Player name: {u.Name}, email: {u.Email}, id: {u.Id}");
    }
}