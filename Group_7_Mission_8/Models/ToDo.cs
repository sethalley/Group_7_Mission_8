using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_7_Mission_8.Models;

public partial class ToDo
{
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public string Quadrant { get; set; }

    public int? CategoryId { get; set; }

    //public string? Category CategoryName {get; set; } maybe add something like this?

    public bool? Completed { get; set; }
}
