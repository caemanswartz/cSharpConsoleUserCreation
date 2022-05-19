using System.Text.RegularExpressions;
List<User> users=new List<User>();
string input="";
int number=-1;
User FindUser(List<User> l,string i)
{
    var u=l.Find(x => x.Name==i);
    return u;
}
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
    users.Add(new User(name,input)); 
    --number;
}
// prompt for user info
do
{
    Console.WriteLine("Enter a user name for info or q to quit");
    input=Console.ReadLine()??string.Empty;
    try
    {
        User u=FindUser(users,input);
        u.PrintUserInfo();
    }
    catch
    {
        if(input!="q")Console.WriteLine($"No user named {input} found.");
    }
}while(input!="q");