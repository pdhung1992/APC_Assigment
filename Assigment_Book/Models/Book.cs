using System;
using System.Collections.Generic;

namespace Assigment_Book.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? BookName { get; set; }

    public int CatId { get; set; }

    public int AuthId { get; set; }

    public int? PublishYear { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual Author? Auth { get; set; }

    public virtual Category? Cat { get; set; }
}
