// <copyright file="Enrollment.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Enrollment
{
    public uint Id { get; set; }

    public uint StudentId { get; set; }

    public uint CourseId { get; set; }

    public uint? UserId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string PaymentPlan { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? StatusDate { get; set; }

    public DateTime? GradEmailDate { get; set; }

    public bool GradEmailSkip { get; set; }

    public uint CurrencyId { get; set; }

    public decimal Cost { get; set; }

    public bool NoShipping { get; set; }

    public bool HideFromShippingList { get; set; }

    public decimal Discount { get; set; }

    public decimal Installment { get; set; }

    public bool PaymentOverride { get; set; }

    public string PaymentFrequency { get; set; } = null!;

    public byte? PaymentDay { get; set; }

    public DateTime? PaymentStart { get; set; }

    public uint? AccountId { get; set; }

    public string? ShippingNote { get; set; }

    public DateTime? PreparedDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public bool Diploma { get; set; }

    public DateTime? DiplomaDate { get; set; }

    public bool? FastTrack { get; set; }

    public bool NoStudentCenter { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual AffiliateId? AffiliateId { get; set; }

    public virtual ICollection<BonusItemShipment> BonusItemShipments { get; set; } = new List<BonusItemShipment>();

    public virtual Course Course { get; set; } = null!;

    public virtual Currency Currency { get; set; } = null!;

    public virtual ICollection<GlobalTransactionBreakdown> GlobalTransactionBreakdowns { get; set; } = new List<GlobalTransactionBreakdown>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual Student Student { get; set; } = null!;

    public virtual ICollection<TaxReceipt> TaxReceipts { get; set; } = new List<TaxReceipt>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
