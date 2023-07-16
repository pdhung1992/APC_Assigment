using Assigment_Book.Context;
using Assigment_Book.Models;

namespace Assigment_Book.Controllers;

public class AuthorManagement
{
    private BookDBContext dbContext = new BookDBContext();
    public void CreateNewAuthor()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter biography: ");
        string bio = Console.ReadLine();

        var newAuthor = new Author
        {
            AuthName = name,
            Biography = bio
        };

        dbContext.Authors.Add(newAuthor);
        dbContext.SaveChanges();
        Console.WriteLine("Author created!");
    }

    public void GetAllAuthor()
    {
        var authors = from a in dbContext.Authors
            select new
            {
                ID = a.Id,
                Name = a.AuthName
            };
        foreach (var author in authors)
        {
            Console.WriteLine("ID: {0}, name: {1}", author.ID, author.Name);
        }
    }

    public void UpdateAuthor()
    {
        Console.WriteLine("Enter author ID to update: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var updateAuthor = dbContext.Authors.FirstOrDefault(a => a.Id == findId);
        if (updateAuthor != null)
        {
            Console.WriteLine("Author found: {0}", updateAuthor.AuthName);
            Console.Write("Enter new name: ");
            updateAuthor.AuthName = Console.ReadLine();
            Console.Write("Enter new biography: ");
            updateAuthor.Biography = Console.ReadLine();

            dbContext.Authors.Update(updateAuthor);
            dbContext.SaveChanges();
            Console.WriteLine("Author updated!");
        }
        else
        {
            Console.WriteLine("Can not find author has ID = {0}", findId);
        }
    }

    public void RemoveAuthor()
    {
        Console.WriteLine("Enter author ID to remove: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var removeAuthor = dbContext.Authors.FirstOrDefault(a => a.Id == findId);
        if (removeAuthor != null)
        {
            Console.WriteLine("Author found: {0}", removeAuthor.AuthName);

            dbContext.Authors.Remove(removeAuthor);
            dbContext.SaveChanges();
            Console.WriteLine("Author removed!");
        }
        else
        {
            Console.WriteLine("Can not find author has ID = {0}", findId);
        }
    }
}