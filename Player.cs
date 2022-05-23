public class Player : User
{
    private readonly Guid _id=Guid.NewGuid();
    private string _email;
    public string Email{get{return _email;} set{_email=value;}}
    public Player(string name, string email) : base(name) {_email=email;}
    public Player(string name, string email, string id) : base(name,id) {_email=email;}
}