using System;
using System.Collections.Generic;

namespace Assigment_Book.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? CatName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
