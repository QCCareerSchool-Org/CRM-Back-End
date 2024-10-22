// <copyright file="Country.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Country
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public ushort? Iso31661 { get; set; }

    public bool Eu { get; set; }

    public bool NoShipping { get; set; }

    public bool? NeedsPostalCode { get; set; }

    public uint StudentCount { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
