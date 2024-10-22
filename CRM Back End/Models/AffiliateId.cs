// <copyright file="AffiliateId.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class AffiliateId
{
    public uint EnrollmentId { get; set; }

    public uint AffiliateId1 { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
