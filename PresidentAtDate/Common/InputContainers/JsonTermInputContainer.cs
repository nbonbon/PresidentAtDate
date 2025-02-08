using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PresidentAtDate.Common.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PresidentAtDate.Common.InputContainers
{
    public class JsonTermInputContainer : ITermInputContainer
    {

        private const string PATH = @"Data\data.json";

        public object JObject { get; private set; }

        public bool QueryTerms()
        {
            return false;
        }


        public List<Term> LoadTerms()
        {
            string jsonContent = File.ReadAllText(PATH);

            return this.LoadTerms(jsonContent);
        }

        public List<Term> LoadTerms(string jsonContent)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new TermConverter());
            settings.Converters.Add(new PortraitConverter());
            settings.Converters.Add(new PresidentConverter());

            List<Term> terms = JsonConvert.DeserializeObject<List<Term>>(jsonContent, settings);

            return terms;
        }
    }
}
