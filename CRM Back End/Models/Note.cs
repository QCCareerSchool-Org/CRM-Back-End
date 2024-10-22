// <copyright file="Note.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Note
{
    public uint Id { get; set; }

    public uint StudentId { get; set; }

    public uint? CourseId { get; set; }

    public uint? UserId { get; set; }

    public string Note1 { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool Starred { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual User? User { get; set; }
}
