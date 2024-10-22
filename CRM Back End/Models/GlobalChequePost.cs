// <copyright file="GlobalChequePost.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GlobalChequePost
{
    public uint GlobalTransactionId { get; set; }

    public sbyte? Success { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual GlobalTransaction GlobalTransaction { get; set; } = null!;
}
