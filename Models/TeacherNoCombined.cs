using System;
using System.Collections.Generic;

namespace Student.Models;

public partial class TeacherNoCombined
{
    public string TeacherId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? CourseCode { get; set; }
}
