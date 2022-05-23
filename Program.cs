using System.Text.RegularExpressions;
using static BotExt;
using static PlayerExt;
string namesPath="names";
string personalityPath="personalities";
List<User> users=new List<User>();
string input="";
int number=-1;
Random rnd=new Random();
User FindUser(List<User> l,string i)
{
    var u=l.Find(x => x.Name==i);
    return u;
}
// load any files saved
users.AddRange(LoadAll(Environment.CurrentDirectory));
Console.WriteLine("Enter number of users to input:");
// get number of users to create
do
{
    try
    {
        input=Console.ReadLine()??string.Empty;
        number=Convert.ToInt32(input);
    }
    catch
    {
        Console.WriteLine($"Error: {input} is not a number. Try again.");
        number=-1;
    }
} while(number<0);
// create users
while(number>0)
{
    Console.WriteLine("Enter new user name:");
    string name=Console.ReadLine()??string.Empty;
    Regex emailValidation=new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    do
    {
        Console.WriteLine("Enter new user email:");
        input=Console.ReadLine()??string.Empty;
    } while (!emailValidation.IsMatch(input));
    User u=new Player(name,input);
    users.Add(u);
    --number;
}
for (int i=users.Count;i>0;--i)
{
    int n=rnd.Next(1,3);
    while(n>0)
    {
        users.Add(GenerateBot(namesPath,personalityPath));
        --n;
    }
}
//delegate function
static void PrintUserInfo(User u)
{
    if (u is Bot) Console.WriteLine($"User name: {u.Name}, personality: {(u as Bot).Personality} id: {u.Id}");
    else if (u is Player) Console.WriteLine($"User name: {u.Name}, email: {(u as Player).Email}, id: {u.Id}");
}
// prompt for user info
do
{
    Console.WriteLine("Enter a user name for info, l to list all, s to save, or q to quit");
    input=Console.ReadLine()??string.Empty;
    if(input=="q")Environment.Exit(0);
    else if (input=="l")
    {
        Console.WriteLine("Displaying all users in list");
        foreach (var u in users)u.Print(PrintUserInfo, u);
    }
    else if(input=="s")
    {
        foreach (User u in users)if(u is Player)await(u as Player).Save();
    }
    else
        try
        {
            User u=FindUser(users,input);
            u.Print(PrintUserInfo,u);
        }
        catch
        {
            if(input!="q")Console.WriteLine($"No user named '{input}' found.");
        }
}while(input!="q");
// display all in list