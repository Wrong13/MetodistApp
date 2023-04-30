using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Group
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdTutor { get; set; }

    public virtual Tutor? IdTutorNavigation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
