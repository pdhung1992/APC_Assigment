using Assigment_Book.Context;
using Assigment_Book.Models;

namespace Assigment_Book.Controllers;

public class BookManagement
{ 
    private BookDBContext dbContext = new BookDBContext();

    public void CreateNewBook()
    {
        Console.Write("Enter book name: ");
        string name = Console.ReadLine();
        Console.Write("Enter category ID: ");
        int catId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter author ID: ");
        int authId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        var newBook = new Book
        {
            BookName = name,
            CatId = catId,
            AuthId = authId,
            Description = desc,
            Price = price
        };

        var category = dbContext.Categories.FirstOrDefault(c => c.Id == catId);
        var author = dbContext.Authors.FirstOrDefault(a => a.Id == authId);
        if (category == null)
        {
            Console.WriteLine("Invalid category ID");
        }
        if (author == null)
        {
            Console.WriteLine("Invalid author ID");
        }
        if (category != null && author != null)
        {
            newBook.Cat = category;
            newBook.Auth = author;

            dbContext.Books.Add(newBook);
            dbContext.SaveChanges();
            Console.WriteLine("Book created!");
        }
        else
        {
            Console.WriteLine("Can not create this book!");
        }
    }

    public void GetAllBook()
    {
        var books = from b in dbContext.Books
            join c in dbContext.Categories on b.CatId equals c.Id
            join a in dbContext.Authors on b.AuthId equals a.Id
            select new
            {
                ID = b.Id,
                Name = b.BookName,
                Category = c.CatName,
                Author = a.AuthName
            };
        foreach (var book in books)
        {
            Console.WriteLine($"{book.ID}, Name: {book.Name}, Category: {book.Category}, Author: {book.Author}");

        }
    }

    public void UpdateBook()
    {
        Console.Write("Enter book ID to update: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var updateBook = dbContext.Books.FirstOrDefault(b => b.Id == findId);
        if (updateBook != null)
        {
            Console.WriteLine("Book found: {0}", updateBook.BookName);
            Console.Write("Enter new book name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new category ID: ");
            int catId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new author ID: ");
            int authId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new description: ");
            string desc = Console.ReadLine();
            Console.Write("Enter new price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            var category = dbContext.Categories.FirstOrDefault(c => c.Id == catId);
            var author = dbContext.Authors.FirstOrDefault(a => a.Id == authId);
            if (category == null)
            {
                Console.WriteLine("Invalid category ID");
            }
            if (author == null)
            {
                Console.WriteLine("Invalid author ID");
            }
            if (category != null && author != null)
            {
                updateBook.BookName = name;
                updateBook.Cat = category;
                updateBook.Auth = author;
                updateBook.Description = desc;
                updateBook.Price = price;

                dbContext.Books.Update(updateBook);
                dbContext.SaveChanges();
                Console.WriteLine("Book updated!");
            }
            else
            {
                Console.WriteLine("Can not update this book!");
            }
        }
        else
        {
            Console.WriteLine("Can not find the book has ID = {0}", findId);
        }
    }

    public void RemoveBook()
    {
        Console.Write("Enter book ID to remove: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var removeBook = dbContext.Books.FirstOrDefault(b => b.Id == findId);
        if (removeBook != null)
        {
            Console.WriteLine("Book found: {0}", removeBook.BookName);

            dbContext.Books.Remove(removeBook);
            dbContext.SaveChanges();
            Console.WriteLine("Book removed!");
        }
        else
        {
            Console.WriteLine("Can not find the book has ID = {0}", findId);
        }
    }
}