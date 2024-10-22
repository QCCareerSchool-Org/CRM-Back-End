// <copyright file="EselectPlusResponse.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class EselectPlusResponse
{
    public uint GlobalTransactionId { get; set; }

    public string OrderId { get; set; } = null!;

    public string ReferenceNumber { get; set; } = null!;

    public sbyte? ResponseCode { get; set; }

    public string AuthCode { get; set; } = null!;

    public TimeOnly TransactionTime { get; set; }

    public DateOnly TransactionDate { get; set; }

    public string Message { get; set; } = null!;

    public string TransactionNumber { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
