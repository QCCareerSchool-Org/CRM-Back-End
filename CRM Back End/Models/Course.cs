// <copyright file="Course.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Course
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Prefix { get; set; } = null!;

    public uint SchoolId { get; set; }

    public int? MaxAssignments { get; set; }

    public uint Order { get; set; }

    public uint EnrollmentCount { get; set; }

    public decimal Cost { get; set; }

    public decimal Installment { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<BonusItemsCourse> BonusItemsCourses { get; set; } = new List<BonusItemsCourse>();

    public virtual ICollection<EmailMessage> EmailMessages { get; set; } = new List<EmailMessage>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual School School { get; set; } = null!;
}
