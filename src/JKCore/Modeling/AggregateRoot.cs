// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TKey">
    /// </typeparam>
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
    {
    }

    /// <summary>
    /// </summary>
    public class AggregateRoot : AggregateRoot<string>
    {
    }
}