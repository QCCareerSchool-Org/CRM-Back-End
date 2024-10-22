// <copyright file="Transaction.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Transaction
{
    public uint Id { get; set; }

    public uint EnrollmentId { get; set; }

    public uint? UserId { get; set; }

    public uint? ParentId { get; set; }

    public DateOnly TransactionDate { get; set; }

    public TimeOnly? TransactionTime { get; set; }

    public decimal Amount { get; set; }

    public decimal AttemptedAmount { get; set; }

    public decimal? UsdAmount { get; set; }

    public decimal Refund { get; set; }

    public decimal Chargeback { get; set; }

    public uint? PaymentMethodId { get; set; }

    public string? OrderId { get; set; }

    public uint? ResponseCode { get; set; }

    public string? AuthorizationCode { get; set; }

    public Guid? ReferenceNumber { get; set; }

    public Guid? SettlementId { get; set; }

    public string? TransactionNumber { get; set; }

    public string? Response { get; set; }

    public string? Description { get; set; }

    public bool? Posted { get; set; }

    public DateTime? PostedDate { get; set; }

    public bool? Notified { get; set; }

    public bool ExtraCharge { get; set; }

    public bool Auto { get; set; }

    public bool Reattempt { get; set; }

    public string TransactionType { get; set; } = null!;

    public bool Voided { get; set; }

    public string? Notes { get; set; }

    public int? Severity { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual ICollection<Transaction> InverseParent { get; set; } = new List<Transaction>();

    public virtual Transaction? Parent { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual TransactionReattemptInfo? TransactionReattemptInfo { get; set; }

    public virtual User? User { get; set; }
}
