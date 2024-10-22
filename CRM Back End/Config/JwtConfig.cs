// <copyright file="JwtConfig.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Config;

using System.ComponentModel.DataAnnotations;

public sealed class JwtConfig
{
    /// <summary>The name of the configuration section.</summary>
    public const string ConfigurationSectionName = "JwtSettings";

    /// <summary>Gets the JWT issuer.</summary>
    [Required]
    required public string Issuer { get; init; }

    /// <summary>Gets the JWT audience.</summary>
    [Required]
    required public string Audience { get; init; }

    /// <summary>Gets the JWT secret key.</summary>
    [Required]
    required public string SecretKey { get; init; }
}
