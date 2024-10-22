// <copyright file="TransactionReattemptInfo.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class TransactionReattemptInfo
{
    public uint TransactionId { get; set; }

    public byte Reattempts { get; set; }

    public bool Success { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;
}
