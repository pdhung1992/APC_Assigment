using System;
using System.Collections.Generic;

namespace Assigment_Book.Models;

public partial class Author
{
    public int Id { get; set; }

    public string? AuthName { get; set; }

    public string? Biography { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
