// Copyright (c) Ho Nguyen. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace JKCore.MessageBus.RabbitMQ
{
    #region

    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;

    #endregion

    /// <summary>
    /// </summary>
    public class BsonFormatter : IBodySerializer, IBodyDeserializer
    {
        /// <summary>
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <returns>
        /// </returns>
        public object Deserialize(byte[] body)
        {
            if (body == null || body.Length == 0) return null;

            using (var ms = new MemoryStream(body))
            using (var reader = new BsonReader(ms))
            {
                var serizlier = new JsonSerializer();
                return serizlier.Deserialize(reader);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public T Deserialize<T>(byte[] body) where T : new()
        {
            if (body == null || body.Length == 0) return default(T);

            using (var ms = new MemoryStream(body))
            using (var reader = new BsonReader(ms))
            {
                var serizlier = new JsonSerializer();
                return serizlier.Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// </returns>
        public byte[] Serialize(object obj)
        {
            if (obj == null) return new byte[0];
            using (var ms = new MemoryStream())
            using (var writer = new BsonWriter(ms))
            {
                var serizlier = new JsonSerializer();
                serizlier.Serialize(writer, obj);
                return ms.ToArray();
            }
        }
    }
}