// <copyright file="Flag.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Flag
{
    public string FlagId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<StudentsFlag> StudentsFlags { get; set; } = new List<StudentsFlag>();
}
