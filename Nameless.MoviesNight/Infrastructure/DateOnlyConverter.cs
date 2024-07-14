using System.Text.Json.Serialization;
using System.Text.Json;

namespace Nameless.MoviesNight.Infrastructure {
    public sealed class DateOnlyConverter : JsonConverter<DateOnly> {
        private readonly string _format;

        public DateOnlyConverter(string? format = null) {
            _format = format ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var value = reader.GetString();

            return string.IsNullOrWhiteSpace(value)
                ? DateOnly.MinValue
                : DateOnly.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_format));
    }
}
