// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    /// <summary>
    ///     An interface represent for a location.
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        ///     Gets or sets Address1
        /// </summary>
        string Address { get; set; }

        /// <summary>
        ///     Gets or sets City
        /// </summary>
        string City { get; set; }

        /// <summary>
        ///     Gets or sets Country
        /// </summary>
        string Country { get; set; }

        /// <summary>
        ///     Gets or sets District
        /// </summary>
        string District { get; set; }

        /// <summary>
        ///     Gets or sets Latitude
        /// </summary>
        double Latitude { get; set; }

        /// <summary>
        ///     Gets or sets Longitude
        /// </summary>
        double Longitude { get; set; }

        /// <summary>
        ///     Gets or sets State
        /// </summary>
        string State { get; set; }

        /// <summary>
        ///     Gets or sets Ward
        /// </summary>
        string Ward { get; set; }
    }
}