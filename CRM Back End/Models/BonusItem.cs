// <copyright file="BonusItem.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class BonusItem
{
    public byte[] BonusItemId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    /// <summary>
    /// at enrollment time, this item will show up in the list of possible bonus items
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// new enrollments should default to getting this item
    /// </summary>
    public bool Default { get; set; }

    /// <summary>
    /// when a new enrollment includes this bonus item, the bonus item shipment will be set into a &quot;shipment pending&quot; state from the start
    /// </summary>
    public bool ShipImmediately { get; set; }

    public decimal? Threshold { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<BonusItemShipment> BonusItemShipments { get; set; } = new List<BonusItemShipment>();

    public virtual ICollection<BonusItemsCourse> BonusItemsCourses { get; set; } = new List<BonusItemsCourse>();
}
