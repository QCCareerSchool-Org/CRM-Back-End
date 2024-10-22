// <copyright file="Student.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class Student
{
    public uint Id { get; set; }

    public uint? UserId { get; set; }

    public string Sex { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public uint? ProvinceId { get; set; }

    public string? PostalCode { get; set; }

    public uint CountryId { get; set; }

    public ushort TelephoneCountryCode { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public uint? CurrencyId { get; set; }

    public DateTime? PaymentStart { get; set; }

    public byte? PaymentDay { get; set; }

    public uint LanguageId { get; set; }

    /// <summary>
    /// hashed password for API access
    /// </summary>
    public string? Password { get; set; }

    public string? E164 { get; set; }

    public bool Sms { get; set; }

    public uint EnrollmentCount { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<GlobalPaymentMethod> GlobalPaymentMethods { get; set; } = new List<GlobalPaymentMethod>();

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Province? Province { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<StudentsFlag> StudentsFlags { get; set; } = new List<StudentsFlag>();

    public virtual User? User { get; set; }
}
