using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PresidentAtDate.Common.Util
{
    internal class TermConverter : JsonConverter<Term>
    {
        public override Term ReadJson(JsonReader reader, Type objectType, Term existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            int number = jObject["number"]?.ToObject<int>() ?? 0;
            Portrait portrait = jObject["portrait"]?.ToObject<Portrait>(serializer);

            string startDateString = jObject["start_date"]?.ToString();
            DateTime startDateTime;
            DateTime.TryParse(startDateString, out startDateTime);

            string endDateString = jObject["end_date"]?.ToString();
            DateTime endDateTime;
            DateTime.TryParse(endDateString, out endDateTime);

            JArray jArray = (JArray)jObject["political_affiliations"];
            string[] stringArray = jArray.ToObject<string[]>();
            PoliticalAffiliation[] politicalAffiliations = Array.ConvertAll(stringArray, affiliation => (PoliticalAffiliation)Enum.Parse(typeof(PoliticalAffiliation), affiliation));

            President president = jObject["president"]?.ToObject<President>(serializer);

            jArray = (JArray)jObject["vice_presidents"];
            string[] vicePresidents = jArray.ToObject<string[]>();

            jArray = (JArray)jObject["election_years"];
            string[] electionYears = jArray.ToObject<string[]>();

            return new Term
            {
                Number = number,
                TermPortrait = portrait,
                StartDateInOffice = startDateTime,
                EndDateInOffice = endDateTime,
                PoliticalAffiliations = politicalAffiliations,
                TermPresident = president,
                VicePresidents = vicePresidents,
                ElectionYears = electionYears
            };
        }

        public override void WriteJson(JsonWriter writer, Term value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
