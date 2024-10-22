// <copyright file="BonusItemsCourse.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class BonusItemsCourse
{
    public byte[] BonusItemCourseId { get; set; } = null!;

    public byte[] BonusItemId { get; set; } = null!;

    public uint CourseId { get; set; }

    public virtual BonusItem BonusItem { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
