using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_7_Mission_8.Models;

public partial class ToDo
{
    public int TaskId { get; set; }

    [Required]
    public string Task { get; set; }

    public DateTime? DueDate { get; set; }
    
    [Required]
    public string Quadrant { get; set; }
    
    public int CategoryId { get; set; }

    public Category? Categories { get; set; }

    public bool? Completed { get; set; }
}
