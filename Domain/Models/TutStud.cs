using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TutStud
{
    public int? TutorId { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Tutor? Tutor { get; set; }
}
