// <copyright file="Language.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Language
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string NativeName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Enabled { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
