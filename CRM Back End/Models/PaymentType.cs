// <copyright file="PaymentType.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class PaymentType
{
    public uint Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}
