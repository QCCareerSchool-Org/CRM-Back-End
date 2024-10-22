// <copyright file="GlobalTransaction.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GlobalTransaction
{
    public uint GlobalTransactionId { get; set; }

    public uint? ParentGlobalTransactionId { get; set; }

    public uint GlobalPaymentMethodId { get; set; }

    /// <summary>
    /// the date this payment is registered for
    /// </summary>
    public DateOnly TransactionDate { get; set; }

    public uint? UserId { get; set; }

    public bool Success { get; set; }

    public bool ExtraCharge { get; set; }

    public decimal AttemptedAmount { get; set; }

    public decimal Amount { get; set; }

    public decimal? RefundedAmount { get; set; }

    public decimal? UsdAmount { get; set; }

    public decimal? UsdRefundedAmount { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public uint? Severity { get; set; }

    public string Origin { get; set; } = null!;

    public bool Voided { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual CardeasexmlResponse? CardeasexmlResponse { get; set; }

    public virtual EselectPlusResponse? EselectPlusResponse { get; set; }

    public virtual GlobalChequePost? GlobalChequePost { get; set; }

    public virtual GlobalPaymentMethod GlobalPaymentMethod { get; set; } = null!;

    public virtual GlobalPaysafeTransaction? GlobalPaysafeTransaction { get; set; }

    public virtual ICollection<GlobalTransactionBreakdown> GlobalTransactionBreakdowns { get; set; } = new List<GlobalTransactionBreakdown>();

    public virtual PaysafeResponse? PaysafeResponse { get; set; }
}
