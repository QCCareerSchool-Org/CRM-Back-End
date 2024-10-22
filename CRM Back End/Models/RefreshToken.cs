// <copyright file="RefreshToken.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class RefreshToken
{
    public byte[] RefreshTokenId { get; set; } = null!;

    public uint? StudentId { get; set; }

    public uint? UserId { get; set; }

    public byte[] Token { get; set; } = null!;

    public DateTime Expiry { get; set; }

    public byte[]? IpAddress { get; set; }

    public string? Browser { get; set; }

    public string? BrowserVersion { get; set; }

    public bool? Mobile { get; set; }

    public string? Os { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Student? Student { get; set; }

    public virtual User? User { get; set; }
}
