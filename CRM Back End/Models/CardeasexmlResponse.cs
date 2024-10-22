// <copyright file="CardeasexmlResponse.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class CardeasexmlResponse
{
    public uint GlobalTransactionId { get; set; }

    public string OrderId { get; set; } = null!;

    public Guid CardEaseReference { get; set; }

    public sbyte? ResultCode { get; set; }

    public string? AuthCode { get; set; }

    /// <summary>
    /// not supplied by processor
    /// </summary>
    public DateTime TransactionTime { get; set; }

    public string? Message { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
