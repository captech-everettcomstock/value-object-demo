using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ValueObjectDemo.Utilities;

namespace ValueObjectDemo.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public class StringEnum : ValueObject
    {
        private string Value { get; set; }

        private StringEnum() { }

        protected StringEnum(string value)
        {
            Guard.AgainstEmpty(value);

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(StringEnum item) => item.Value;

        public static explicit operator StringEnum(string value) => new StringEnum(value);
    }

    public class StringEnumConverter : JsonConverter<StringEnum>
    {
        public override void WriteJson(JsonWriter writer, [AllowNull] StringEnum value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override StringEnum ReadJson(JsonReader reader, Type objectType, [AllowNull] StringEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;

            return (StringEnum)value;
        }
    }
}
