// <copyright file="School.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class School
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public uint CourseCount { get; set; }

    public string StudentCenterAccountType { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
