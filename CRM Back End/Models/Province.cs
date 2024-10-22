// <copyright file="Province.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Province
{
    public uint Id { get; set; }

    public uint CountryId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public uint StudentCount { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
