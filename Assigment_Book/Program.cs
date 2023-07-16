using Assigment_Book.Controllers;

Console.WriteLine("=== Book Management Program ===");

do
{
    BookManagement bookManagement = new BookManagement();
    CategoryManagement categoryManagement = new CategoryManagement();
    AuthorManagement authorManagement = new AuthorManagement();
    Console.WriteLine("1. Create new book");
    Console.WriteLine("2. Display all books");
    Console.WriteLine("3. Update book");
    Console.WriteLine("4. Remove book");
    Console.WriteLine("5. Create new category");
    Console.WriteLine("6. Display all categories");
    Console.WriteLine("7. Update category");
    Console.WriteLine("8. Remove category");
    Console.WriteLine("9. Create new author");
    Console.WriteLine("10. Display all authors");
    Console.WriteLine("11. Update author");
    Console.WriteLine("12. Remove author");
    Console.WriteLine("0. Exit");
    
    Console.Write("Enter your choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            bookManagement.CreateNewBook();
            break;
        case 2:
            bookManagement.GetAllBook();
            break;
        case 3:
            bookManagement.UpdateBook();
            break;
        case 4:
            bookManagement.RemoveBook();
            break;
        case 5:
            categoryManagement.CreateNewCategory();
            break;
        case 6:
            categoryManagement.GetAllCategory();
            break;
        case 7:
            categoryManagement.UpdateCategory();
            break;
        case 8:
            categoryManagement.RemoveCategory();
            break;
        case 9:
            authorManagement.CreateNewAuthor();
            break;
        case 10:
            authorManagement.GetAllAuthor();
            break;
        case 11:
            authorManagement.UpdateAuthor();
            break;
        case 12:
            authorManagement.RemoveAuthor();
            break;
        case 0:
            Console.WriteLine("Program ended!");
            return;
    }
} while (true);