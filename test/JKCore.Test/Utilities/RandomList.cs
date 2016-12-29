namespace JKCore.Test.Utilities
{
    #region

    using System;
    using System.Collections.Generic;

    using GenFu;

    #endregion

    /// <summary>
    ///     The random list.
    /// </summary>
    public static class RandomList
    {
        /// <summary>
        ///     The of.
        /// </summary>
        /// <param name="count">
        ///     The count.
        /// </param>
        /// <param name="customFiller">
        ///     The custom filler.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public static IEnumerable<T> Of<T>(int count = 10, Func<T, T> customFiller = null) where T : new()
        {
            while (count-- > 0)
            {
                var item = GenFu.New<T>();
                if (customFiller != null)
                {
                    item = customFiller(item);
                }

                yield return item;
            }
        }
    }
}