// <copyright file="PaysafeToken.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class PaysafeToken
{
    public uint GlobalPaymentMethodId { get; set; }

    public Guid ProfileId { get; set; }

    public Guid CardId { get; set; }

    public string PaymentToken { get; set; } = null!;

    public string Company { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalPaymentMethod GlobalPaymentMethod { get; set; } = null!;
}
