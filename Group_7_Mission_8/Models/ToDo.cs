using System;
using System.Collections.Generic;

namespace Group_7_Mission_8.Models;

public partial class ToDo
{
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public int? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    //public string? Category CategoryName {get; set; } maybe add something like this?

    public int? Completed { get; set; }
}
