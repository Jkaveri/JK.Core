// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.Modeling
{
    /// <summary>
    ///     A interface represent a Aggregate Root.
    /// </summary>
    /// <typeparam name="TKey">Aggregate root key</typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
    }
}