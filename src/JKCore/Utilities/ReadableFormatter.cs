// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System.Linq;

    using JKCore.Modeling;

    #endregion

    /// <summary>
    /// </summary>
    public static class ReadableFormatter
    {
        /// <summary>
        /// </summary>
        /// <param name="location">
        ///     The location.
        /// </param>
        /// <returns>
        /// </returns>
        public static string GetFullAddress(ILocation location)
        {
            return GetFullAddress(location.Address, location.State, location.City, location.Country);
        }

        /// <summary>
        /// </summary>
        /// <param name="address">
        ///     The address.
        /// </param>
        /// <param name="state">
        ///     The state.
        /// </param>
        /// <param name="city">
        ///     The city.
        /// </param>
        /// <param name="country">
        ///     The country.
        /// </param>
        /// <returns>
        /// </returns>
        public static string GetFullAddress(
            string address = "",
            string state = "",
            string city = "",
            string country = "")
        {
            return string.Join(", ", new[] { address, state, city, country }.Where(t => !string.IsNullOrEmpty(t)));
        }
    }
}