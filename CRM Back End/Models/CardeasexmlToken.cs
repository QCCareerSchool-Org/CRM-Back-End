// <copyright file="CardeasexmlToken.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class CardeasexmlToken
{
    public uint GlobalPaymentMethodId { get; set; }

    public string CardHash { get; set; } = null!;

    public Guid CardReference { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalPaymentMethod GlobalPaymentMethod { get; set; } = null!;
}
