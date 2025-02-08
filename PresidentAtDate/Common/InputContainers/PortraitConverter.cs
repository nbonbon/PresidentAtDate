using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PresidentAtDate.Common.InputContainers
{
    internal class PortraitConverter : JsonConverter<Portrait>
    {
        public override Portrait ReadJson(JsonReader reader, Type objectType, Portrait existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            string onlineUriString = jObject["online_uri"]?.ToString();
            Uri onlineUri = null;
            try
            {
                onlineUri = new Uri(onlineUriString);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error - Online uri was null: " + e.Message);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine("Error - Online uri format was invlaid: " + e.Message);
            }


            string localUriString = jObject["local_uri"]?.ToString();
            Uri localUri = null;
            try
            {
                localUri = new Uri(localUriString);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error - Local uri was null: " + e.Message);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine("Error - Local uri format was invlaid: " + e.Message);
            }

            return new Portrait
            {
                OnlineUri = onlineUri,
                LocalUri = localUri
            };
        }

        public override void WriteJson(JsonWriter writer, Portrait value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}