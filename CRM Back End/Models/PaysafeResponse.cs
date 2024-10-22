// <copyright file="PaysafeResponse.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class PaysafeResponse
{
    public uint GlobalTransactionId { get; set; }

    public Guid AuthorizationId { get; set; }

    public string MerchantRefNum { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime TxnTime { get; set; }

    public string AuthCode { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
