// <copyright file="Currency.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Currency
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public decimal? ExchangeRate { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
