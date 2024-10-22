// <copyright file="GlobalTransactionBreakdown.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GlobalTransactionBreakdown
{
    public uint GlobalTransactionBreakdownId { get; set; }

    public uint GlobalTransactionId { get; set; }

    public uint EnrollmentId { get; set; }

    public decimal Amount { get; set; }

    public decimal AttemptedAmount { get; set; }

    public decimal? UsdAmount { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
