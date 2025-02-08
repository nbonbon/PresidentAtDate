using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PresidentAtDate.Common.InputContainers
{
    internal class PresidentConverter : JsonConverter<President>
    {
        public override President ReadJson(JsonReader reader, Type objectType, President existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            string name = jObject["name"]?.ToString();

            string birthDateString = jObject["birth_date"]?.ToString();
            DateTime birthDateTime;
            DateTime.TryParse(birthDateString, out birthDateTime);

            string deathDateString = jObject["death_date"]?.ToString();
            DateTime deathDateTime;
            DateTime.TryParse(deathDateString, out deathDateTime);

            return new President
            {
                Name = name,
                BirthDate = birthDateTime,
                DeathDate = deathDateTime
            };
        }

        public override void WriteJson(JsonWriter writer, President value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}