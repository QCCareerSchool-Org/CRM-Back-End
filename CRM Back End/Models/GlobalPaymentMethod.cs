// <copyright file="GlobalPaymentMethod.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GlobalPaymentMethod
{
    public uint GlobalPaymentMethodId { get; set; }

    public uint? UserId { get; set; }

    public uint StudentId { get; set; }

    public string GlobalPaymentTypeId { get; set; } = null!;

    public bool Primary { get; set; }

    public string? MaskedPan { get; set; }

    public byte? ExpiryMonth { get; set; }

    public ushort? ExpiryYear { get; set; }

    public bool Deleted { get; set; }

    public uint GlobalTransactionCount { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual CardeasexmlToken? CardeasexmlToken { get; set; }

    public virtual EselectPlusToken? EselectPlusToken { get; set; }

    public virtual ICollection<GlobalTransaction> GlobalTransactions { get; set; } = new List<GlobalTransaction>();

    public virtual PaysafeToken? PaysafeToken { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual User? User { get; set; }
}
