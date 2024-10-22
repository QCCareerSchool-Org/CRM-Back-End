// <copyright file="CountryCallingCode.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class CountryCallingCode
{
    public uint Id { get; set; }

    public ushort Code { get; set; }

    public string Region { get; set; } = null!;
}
