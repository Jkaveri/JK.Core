// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Utilities
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     A value converter class.
    /// </summary>
    public class ValueConverter
    {
        private readonly object _value;

        /// <summary>
        ///     Construct value parser with a value which needs to be convert.
        /// </summary>
        /// <param name="value"></param>
        public ValueConverter(object value)
        {
            this._value = value;
        }

        /// <summary>
        ///     Convert a value to {T}.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">A value which is need to be converted</param>
        /// <returns>A value of {T} which was converted.</returns>
        public static T To<T>(object value) where T : struct
        {
            return new ValueConverter(value).As<T>();
        }

        /// <summary>
        ///     Convert object to boolean with default value.
        /// </summary>
        /// <param name="value">Value needs to be converted.</param>
        /// <param name="defaultValue">A default value when the value cannot be converted.</param>
        /// <returns>A <see cref="bool" /> value after converted.</returns>
        public static bool ToBoolean(object value, bool defaultValue = false)
        {
            if (value == null)
            {
                return defaultValue;
            }

            bool result;
            bool.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static DateTime ToDateTime(object value, DateTime? defaultValue = null)
        {
            if (value == null)
            {
                return defaultValue ?? default(DateTime);
            }

            DateTime result;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static decimal ToDecimal(object value, decimal defaultValue = default(decimal))
        {
            if (value == null)
            {
                return defaultValue;
            }

            decimal result;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static double ToDouble(object value, double defaultValue = default(double))
        {
            if (value == null)
            {
                return defaultValue;
            }

            double result;
            double.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static short ToInt16(object value, short defaultValue = default(short))
        {
            if (value == null)
            {
                return defaultValue;
            }

            short result;
            short.TryParse(value.ToString(), out result);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static int ToInt32(object value, int defaultValue = default(int))
        {
            if (value == null)
            {
                return defaultValue;
            }

            int result;
            if (int.TryParse(value.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        /// </returns>
        public static string ToString(object value, string defaultValue = "")
        {
            if (value == null)
            {
                return defaultValue;
            }

            return Convert.ToString(value);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public T As<T>() where T : struct
        {
            var type = typeof(T);
            var typeName = type.Name.ToLower();

            try
            {
                if (typeName == "int32")
                {
                    object box = Convert.ToInt32(this._value);
                    return (T)box;
                }

                if (typeName == "string")
                {
                    object box = Convert.ToString(this._value);
                    return (T)box;
                }

                if (typeName == "boolean")
                {
                    object box = Convert.ToBoolean(this._value);
                    return (T)box;
                }

                if (typeName == "datetime")
                {
                    object box = Convert.ToDateTime(this._value);
                    return (T)box;
                }

                if (typeName == "double")
                {
                    object box = Convert.ToDouble(this._value);
                    return (T)box;
                }

                if (typeName == "decimal")
                {
                    object box = Convert.ToDecimal(this._value);
                    return (T)box;
                }
            }
            catch (Exception)
            {
                return default(T);
            }

            return default(T);
        }
    }
}