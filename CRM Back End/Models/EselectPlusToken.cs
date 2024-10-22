// <copyright file="EselectPlusToken.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class EselectPlusToken
{
    public uint GlobalPaymentMethodId { get; set; }

    public string DataKey { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalPaymentMethod GlobalPaymentMethod { get; set; } = null!;
}
