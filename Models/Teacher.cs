using System;
using System.Collections.Generic;

namespace Student.Models;

public partial class Teacher
{
    public string TeacherId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? CourseCode { get; set; }

    public virtual ICollection<StudentDetail> StudentDetails { get; set; } = new List<StudentDetail>();
}
