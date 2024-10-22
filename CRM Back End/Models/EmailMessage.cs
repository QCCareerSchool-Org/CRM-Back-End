// <copyright file="EmailMessage.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class EmailMessage
{
    public uint Id { get; set; }

    public uint? CourseId { get; set; }

    public uint EmailMessageTypeId { get; set; }

    public string Sender { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Course? Course { get; set; }

    public virtual EmailMessageType EmailMessageType { get; set; } = null!;
}
