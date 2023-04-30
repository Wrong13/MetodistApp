using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Tutor
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
