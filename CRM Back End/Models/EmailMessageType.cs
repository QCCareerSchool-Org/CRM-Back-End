// <copyright file="EmailMessageType.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class EmailMessageType
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<EmailMessage> EmailMessages { get; set; } = new List<EmailMessage>();
}
