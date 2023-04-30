using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Student
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual Group? Group { get; set; }
}
