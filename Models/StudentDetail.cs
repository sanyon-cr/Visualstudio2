using System;
using System.Collections.Generic;

namespace Student.Models;

public partial class StudentDetail
{
    
    public short StudentId { get; set; }

    public string Title { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string? CourseCode { get; set; }

    public string TeacherId { get; set; } = null!;

    public virtual StudentGrade? CourseCodeNavigation { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
