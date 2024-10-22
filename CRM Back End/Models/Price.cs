// <copyright file="Price.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Price
{
    public uint Id { get; set; }

    public uint CourseId { get; set; }

    public uint? CountryId { get; set; }

    public uint? ProvinceId { get; set; }

    public uint CurrencyId { get; set; }

    public decimal Cost { get; set; }

    public decimal ShippingCost { get; set; }

    public byte Enabled { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Currency Currency { get; set; } = null!;

    public virtual Province? Province { get; set; }
}
