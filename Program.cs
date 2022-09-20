using csharp_biblioteca;

Library library = new Library();

library.Add(
    new Book(
        "In Search of Lost Time",
        1913,
        300));
library.Add(
    new Book(
        "Ulysses",
        1904,
        120));
library.Add(
    new Book(
        "A Lost Lady",
        1923,
        90));
library.Add(
    new DVD(
        "The Automat",
        2022,
        120));
library.Add(
    new DVD(
        "The Godfather",
        2001,
        140));

User? user = null;
int choice;

do
{
    PrintOptions();
    choice = GetUserChoice();

    switch (choice)
    {
        case 1:
            user = RegisterUser();
            break;
        case 2:
            FindItemByCode(user);
            break;
        case 3:
            FindItemByTitle(user);
            break;
    }
    
    Console.WriteLine();
} while (choice != -1);

void FindItemByTitle(User? user)
{
    if (user is null)
    {
        Console.WriteLine("You must register your account before searching anything.");
        return;
    }
    
    Console.WriteLine("Please, enter the title you want to search for:");
    Console.Write("> ");
    
    string title = Console.ReadLine() ?? "Test";
    List<Item> items = user.SearchByTitle(library, title);

    if (items.Count > 0)
    {
        Console.WriteLine("Here's the results:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine($"There's no item with title {title}.");
    }
    
}

void FindItemByCode(User? user)
{
    if (user is null)
    {
        Console.WriteLine("You must register your account before searching anything.");
        return;
    }
    
    Console.WriteLine("Please, enter the code you want to search for:");
    Console.Write("> ");
    
    string code = Console.ReadLine() ?? "0000000000000";

    try
    {
        Item item = user.SearchByCode(library, code);
        Console.WriteLine("Here's the result:");
        Console.WriteLine(item);
    }
    catch (InvalidOperationException _)
    {
        Console.WriteLine($"Impossible to find an item with code {code}.");
    }
}

User RegisterUser()
{
    Console.WriteLine("Please, enter your details:");
    Console.Write("First Name: ");
    string firstName = Console.ReadLine() ?? "DummyFirst";
    
    Console.WriteLine();
    
    Console.Write("Last Name: ");
    string lastName = Console.ReadLine() ?? "DummyLast";
    
    Console.WriteLine();
    
    Console.Write("Email: ");
    string email = Console.ReadLine() ?? "DummyEmail@dummy.com";
    
    Console.WriteLine();
    
    Console.Write("Password: ");
    string password = Console.ReadLine() ?? "DummyPassword";
    
    Console.WriteLine();
    
    Console.Write("Phone Number: ");
    string phoneNumber = Console.ReadLine() ?? "3333333333";
    
    Console.WriteLine();

    return new User(
        firstName, lastName, email, password, phoneNumber);
}

int GetUserChoice()
{
    int choice = Convert.ToInt32(Console.ReadLine());
    return choice;
}

void PrintOptions()
{
    Console.WriteLine("Select what you want to do (-1 to abort):");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Find an item by his code");
    Console.WriteLine("3. Find an item by his title");
    Console.Write("> ");
}

/*
User user = new User(
    "Giorgio",
    "Verzicco",
    "example@example.com",
    "password123",
    "3489363992");
    
Library library = new Library();
library.Add(new Book(
    "TestBook", 
    2022,
    300,
    "Fantasy", 
    "C-02", 
    new Author("Robert", "Martin")));
    
library.Add(new DVD(
    "TestDVD", 
    2018,
    138,
    "Rock", 
    "A-11", 
    new Author("Lilo", "Stitch")));

foreach (var item in user.SearchByTitle(library, "Test"))
{
   Console.WriteLine(item.Code);
}
*/