// <copyright file="BonusItemShipment.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class BonusItemShipment
{
    public byte[] BonusItemShipmentId { get; set; } = null!;

    public uint EnrollmentId { get; set; }

    public byte[] BonusItemId { get; set; } = null!;

    public decimal? Threshold { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Qualified { get; set; }

    public DateTime? Prepared { get; set; }

    public DateTime? Shipped { get; set; }

    public virtual BonusItem BonusItem { get; set; } = null!;

    public virtual Enrollment Enrollment { get; set; } = null!;
}
