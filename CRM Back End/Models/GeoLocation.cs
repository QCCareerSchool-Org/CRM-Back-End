// <copyright file="GeoLocation.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Models;

public partial class GeoLocation
{
    public uint StudentId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
}
