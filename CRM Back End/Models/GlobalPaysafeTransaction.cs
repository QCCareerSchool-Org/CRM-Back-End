// <copyright file="GlobalPaysafeTransaction.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GlobalPaysafeTransaction
{
    public uint GlobalTransactionId { get; set; }

    public Guid AuthorizationId { get; set; }

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
