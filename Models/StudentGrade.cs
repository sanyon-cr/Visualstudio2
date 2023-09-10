using System;
using System.Collections.Generic;

namespace Student.Models;

public partial class StudentGrade
{
    public string CourseCode { get; set; } = null!;

    public string? CourseTitle { get; set; }

    public short? Unit { get; set; }

    public decimal? Grade { get; set; }

    public virtual ICollection<StudentDetail> StudentDetails { get; set; } = new List<StudentDetail>();
}
