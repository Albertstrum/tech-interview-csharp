using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vehicles.Api.Models.Converters
{
    // TODO: Make generic somehow, so it can be reused for other date formats
    // TODO: Add unit tests because DateTime has a million ways it likes to explode! 
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (DateTime.TryParseExact(dateString, _format, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            throw new JsonException($"Unable to convert \"{dateString}\" to DateTime.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
