// <copyright file="User.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class User
{
    public uint Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    /// <summary>
    /// add and delete users, modify user permissions
    /// </summary>
    public bool AdminPriv { get; set; }

    /// <summary>
    /// modify, charge, and refund credit cards, print bank deposit sheets
    /// </summary>
    public bool AccountingPriv { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<GlobalPaymentMethod> GlobalPaymentMethods { get; set; } = new List<GlobalPaymentMethod>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<StudentsFlag> StudentsFlags { get; set; } = new List<StudentsFlag>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
