﻿using Confluent.Kafka;

namespace Nucleotidz.Kafka.Serializer
{
    internal class NuceloJsonDeserializer<T> : Confluent.SchemaRegistry.Serdes.JsonDeserializer<T>, IAsyncDeserializer<T>
        where T : class
    {
        public NuceloJsonDeserializer()
            : base()
        { }
        public new Task<T> DeserializeAsync(ReadOnlyMemory<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
            {
                return Task.FromResult(default(T));
            }
            else
            {
                return base.DeserializeAsync(data, isNull, context);
            }
        }
    }

}