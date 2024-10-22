// <copyright file="PaymentMethod.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

/// <summary>
/// history of payment methods used by enrollments
/// </summary>
public partial class PaymentMethod
{
    public uint Id { get; set; }

    public uint? EnrollmentId { get; set; }

    public uint PaymentTypeId { get; set; }

    public bool Primary { get; set; }

    public string? EselectPlusDataKey { get; set; }

    public string? EselectPlusIssuerId { get; set; }

    public string? CardeasexmlCardHash { get; set; }

    public Guid? CardeasexmlCardReference { get; set; }

    public Guid? PaysafeProfileId { get; set; }

    public Guid? PaysafeCardId { get; set; }

    public Guid? PaysafePaymentToken { get; set; }

    public string? PaysafeCompany { get; set; }

    public Guid? InitialTransactionId { get; set; }

    public string? Pan { get; set; }

    public byte? ExpiryMonth { get; set; }

    public ushort? ExpiryYear { get; set; }

    public bool Deleted { get; set; }

    public bool? Notified { get; set; }

    public bool Disabled { get; set; }

    public uint TransactionCount { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Enrollment? Enrollment { get; set; }

    public virtual PaymentType PaymentType { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
