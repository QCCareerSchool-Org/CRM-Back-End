// <copyright file="TaxReceipt.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class TaxReceipt
{
    public uint Id { get; set; }

    public uint EnrollmentId { get; set; }

    public string Type { get; set; } = null!;

    public virtual Enrollment Enrollment { get; set; } = null!;
}
