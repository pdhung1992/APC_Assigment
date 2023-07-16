using Assigment_Book.Context;
using Assigment_Book.Models;

namespace Assigment_Book.Controllers;

public class CategoryManagement
{
    private BookDBContext dbContext = new BookDBContext();
    public void CreateNewCategory()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        var newCategory = new Category
        {
            CatName = name
        };

        dbContext.Categories.Add(newCategory);
        dbContext.SaveChanges();
        Console.WriteLine("Category created!");
    }

    public void GetAllCategory()
    {
        var categories = from c in dbContext.Categories
            select new
            {
                ID = c.Id,
                Name = c.CatName
            };
        foreach (var category in categories)
        {
            Console.WriteLine("ID: {0}, name: {1}", category.ID, category.Name);
        }
    }

    public void UpdateCategory()
    {
        Console.WriteLine("Enter category ID to update: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var updateCategory = dbContext.Categories.FirstOrDefault(c => c.Id == findId);
        if (updateCategory != null)
        {
            Console.WriteLine("Category found: {0}", updateCategory.CatName);
            Console.Write("Enter new name: ");
            updateCategory.CatName = Console.ReadLine();

            dbContext.Categories.Update(updateCategory);
            dbContext.SaveChanges();
            Console.WriteLine("Category updated!");
        }
        else
        {
            Console.WriteLine("Can not find Category has ID = {0}", findId);
        }
    }

    public void RemoveCategory()
    {
        Console.WriteLine("Enter category ID to remove: ");
        int findId = Convert.ToInt32(Console.ReadLine());

        var removeCategory = dbContext.Categories.FirstOrDefault(c => c.Id == findId);
        if (removeCategory != null)
        {
            Console.WriteLine("Category found: {0}", removeCategory.CatName);

            dbContext.Categories.Remove(removeCategory);
            dbContext.SaveChanges();
            Console.WriteLine("Category removed!");
        }
        else
        {
            Console.WriteLine("Can not find Category has ID = {0}", findId);
        }
    }
}