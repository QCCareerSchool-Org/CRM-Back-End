// <copyright file="StudentsFlag.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class StudentsFlag
{
    public byte[] StudentsFlagId { get; set; } = null!;

    public uint StudentId { get; set; }

    public string FlagId { get; set; } = null!;

    public uint? UserId { get; set; }

    public DateTime Created { get; set; }

    public virtual Flag Flag { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual User? User { get; set; }
}
