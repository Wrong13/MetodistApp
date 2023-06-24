using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Domain.Models;

public partial class Tutor
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public int Experience { get; set; }

    public string Education { get; set; }

    public virtual List<Group> Groups { get; set; } = new List<Group>();
    public virtual List<Attestation> Attestations { get; set; } = new List<Attestation>();

    public virtual List<TrainingCourse> TrainingCourses { get; set; } = new List<TrainingCourse>();
}
